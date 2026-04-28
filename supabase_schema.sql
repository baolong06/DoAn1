-- ============================================================
--  SPAMBOT DETECTION SYSTEM — Supabase / PostgreSQL Schema
--  Tác giả  : Senior Engineer Review
--  Phiên bản: 1.0.0
--  Ghi chú  : Dùng Supabase Auth cho authentication —
--             KHÔNG tự lưu password hash vào bảng users.
--             Bảng `users` chỉ lưu profile + role.
-- ============================================================

-- ─────────────────────────────────────────────
--  EXTENSIONS
-- ─────────────────────────────────────────────
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";      -- uuid_generate_v4()
CREATE EXTENSION IF NOT EXISTS "pgcrypto";       -- gen_random_uuid() (fallback)


-- ─────────────────────────────────────────────
--  ENUM TYPES
-- ─────────────────────────────────────────────
DO $$
BEGIN
    -- Role của người dùng hệ thống
    IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'user_role') THEN
        CREATE TYPE user_role AS ENUM ('admin', 'user');
    END IF;

    -- Kết quả phân loại từ AI model
    IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'prediction_label') THEN
        CREATE TYPE prediction_label AS ENUM ('spam', 'real', 'unknown');
    END IF;
END $$;


-- ============================================================
--  TABLE 1: users
--  Lưu thông tin profile người dùng hệ thống (KHÔNG lưu password).
--  auth.uid() từ Supabase Auth là foreign key ngầm định.
-- ============================================================
CREATE TABLE IF NOT EXISTS public.users (
    id          UUID          PRIMARY KEY DEFAULT uuid_generate_v4(),

    -- Khớp với auth.users.id của Supabase Auth
    auth_id     UUID          UNIQUE NOT NULL,

    username    VARCHAR(50)   NOT NULL
                    CONSTRAINT uq_users_username UNIQUE
                    CONSTRAINT chk_username_length CHECK (char_length(username) >= 3),

    display_name VARCHAR(100),

    role        user_role     NOT NULL DEFAULT 'user',

    is_active   BOOLEAN       NOT NULL DEFAULT TRUE,

    created_at  TIMESTAMPTZ   NOT NULL DEFAULT NOW(),
    updated_at  TIMESTAMPTZ   NOT NULL DEFAULT NOW()
);

COMMENT ON TABLE  public.users             IS 'Profile người dùng hệ thống. Password do Supabase Auth quản lý.';
COMMENT ON COLUMN public.users.auth_id     IS 'Liên kết với auth.users.id (Supabase Auth).';
COMMENT ON COLUMN public.users.role        IS 'admin: toàn quyền | user: chỉ scan + xem lịch sử.';


-- ============================================================
--  TABLE 2: scan_history
--  Lưu kết quả mỗi lần phân tích tài khoản.
--  InputData lưu dạng JSONB để linh hoạt với feature vector.
-- ============================================================
CREATE TABLE IF NOT EXISTS public.scan_history (
    id              UUID            PRIMARY KEY DEFAULT uuid_generate_v4(),

    -- Ai thực hiện scan (nullable: hệ thống tự động không cần user)
    scanned_by      UUID            REFERENCES public.users(id) ON DELETE SET NULL,

    -- Tên/ID tài khoản mạng xã hội được quét
    account_name    VARCHAR(150)    NOT NULL,

    -- Raw feature JSON gửi lên AI API
    -- Ví dụ: {"followers_count":350,"friends_count":280,...}
    input_data      JSONB           NOT NULL DEFAULT '{}',

    -- Kết quả từ model
    prediction      prediction_label NOT NULL DEFAULT 'unknown',
    confidence      NUMERIC(5, 4)   NOT NULL DEFAULT 0
                        CONSTRAINT chk_confidence_range CHECK (confidence BETWEEN 0 AND 1),
    prob_spam       NUMERIC(5, 4)   CONSTRAINT chk_prob_spam CHECK (prob_spam BETWEEN 0 AND 1),
    prob_real       NUMERIC(5, 4)   CONSTRAINT chk_prob_real CHECK (prob_real BETWEEN 0 AND 1),

    -- Metadata từ API response (model version, feature_vector, ...)
    api_response    JSONB           DEFAULT '{}',

    -- Scan từ batch CSV hay single check?
    scan_source     VARCHAR(20)     NOT NULL DEFAULT 'single'
                        CONSTRAINT chk_scan_source CHECK (scan_source IN ('single', 'batch_csv', 'api')),

    -- Ghi chú thủ công của người dùng (UC02: nút "Lưu kết quả")
    note            TEXT,

    created_at      TIMESTAMPTZ     NOT NULL DEFAULT NOW()

    -- Không có updated_at: lịch sử không được sửa, chỉ được xóa (audit trail)
);

COMMENT ON TABLE  public.scan_history               IS 'Lịch sử mỗi lần quét tài khoản. Append-only.';
COMMENT ON COLUMN public.scan_history.input_data    IS 'Feature JSON gửi đến AI API. Lưu JSONB để query sau.';
COMMENT ON COLUMN public.scan_history.api_response  IS 'Full response từ AI để debug & audit.';
COMMENT ON COLUMN public.scan_history.confidence    IS 'Độ tin cậy tổng [0-1]. Max(prob_spam, prob_real).';


-- ============================================================
--  TABLE 3: blacklist
--  Danh sách tài khoản đã được Admin xác nhận là bot.
-- ============================================================
CREATE TABLE IF NOT EXISTS public.blacklist (
    id              UUID            PRIMARY KEY DEFAULT uuid_generate_v4(),

    -- ID tài khoản trên mạng xã hội (Twitter ID, v.v.)
    account_id      VARCHAR(150)    NOT NULL
                        CONSTRAINT uq_blacklist_account UNIQUE,

    account_name    VARCHAR(150),

    reason          TEXT,

    -- Độ tin cậy lúc thêm vào blacklist (từ scan gốc)
    confidence_at_add NUMERIC(5, 4)
                        CONSTRAINT chk_bl_conf CHECK (confidence_at_add BETWEEN 0 AND 1),

    -- Liên kết ngược về scan gốc (nullable: có thể thêm tay)
    source_scan_id  UUID            REFERENCES public.scan_history(id) ON DELETE SET NULL,

    -- Admin nào thêm vào
    added_by        UUID            REFERENCES public.users(id) ON DELETE SET NULL,

    -- Còn hiệu lực không? (soft delete thay vì xóa cứng)
    is_active       BOOLEAN         NOT NULL DEFAULT TRUE,

    added_at        TIMESTAMPTZ     NOT NULL DEFAULT NOW(),
    updated_at      TIMESTAMPTZ     NOT NULL DEFAULT NOW()
);

COMMENT ON TABLE  public.blacklist                    IS 'Danh sách đen tài khoản bot đã xác nhận.';
COMMENT ON COLUMN public.blacklist.account_id         IS 'ID nền tảng (Twitter, v.v.). Unique constraint.';
COMMENT ON COLUMN public.blacklist.is_active          IS 'FALSE = soft-deleted. Không xóa record để giữ audit trail.';
COMMENT ON COLUMN public.blacklist.source_scan_id     IS 'Scan nào tạo ra blacklist entry này. NULL = thêm tay.';


-- ============================================================
--  TABLE 4: api_config
--  Lưu URL Ngrok và các cấu hình AI endpoint (UC05).
--  Tách riêng để Admin có thể cập nhật mà không restart app.
-- ============================================================
CREATE TABLE IF NOT EXISTS public.api_config (
    id              UUID            PRIMARY KEY DEFAULT uuid_generate_v4(),

    config_key      VARCHAR(100)    NOT NULL CONSTRAINT uq_config_key UNIQUE,
    config_value    TEXT            NOT NULL,
    description     TEXT,
    is_sensitive    BOOLEAN         NOT NULL DEFAULT FALSE,  -- mask trong UI nếu TRUE

    updated_by      UUID            REFERENCES public.users(id) ON DELETE SET NULL,
    updated_at      TIMESTAMPTZ     NOT NULL DEFAULT NOW()
);

COMMENT ON TABLE public.api_config IS 'Cấu hình runtime: Ngrok URL, model version, threshold, v.v.';

-- Seed dữ liệu mặc định
INSERT INTO public.api_config (config_key, config_value, description, is_sensitive)
VALUES
    ('ngrok_base_url',      '',         'URL public của Ngrok tunnel (thay đổi mỗi lần restart Colab)', FALSE),
    ('predict_endpoint',    '/predict', 'Path endpoint predict đơn lẻ', FALSE),
    ('batch_endpoint',      '/predict/batch', 'Path endpoint predict batch', FALSE),
    ('confidence_threshold','0.5',      'Ngưỡng confidence để kết luận spam', FALSE),
    ('max_batch_size',      '500',      'Số lượng account tối đa mỗi batch request', FALSE),
    ('request_timeout_sec', '30',       'Timeout (giây) khi gọi AI API', FALSE)
ON CONFLICT (config_key) DO NOTHING;


-- ─────────────────────────────────────────────
--  INDEXES
-- ─────────────────────────────────────────────

-- users
CREATE INDEX IF NOT EXISTS idx_users_auth_id    ON public.users(auth_id);
CREATE INDEX IF NOT EXISTS idx_users_role       ON public.users(role);

-- scan_history
CREATE INDEX IF NOT EXISTS idx_scan_scanned_by  ON public.scan_history(scanned_by);
CREATE INDEX IF NOT EXISTS idx_scan_account     ON public.scan_history(account_name);
CREATE INDEX IF NOT EXISTS idx_scan_prediction  ON public.scan_history(prediction);
CREATE INDEX IF NOT EXISTS idx_scan_created_at  ON public.scan_history(created_at DESC);
CREATE INDEX IF NOT EXISTS idx_scan_source      ON public.scan_history(scan_source);
-- GIN index để query bên trong JSONB input_data
CREATE INDEX IF NOT EXISTS idx_scan_input_gin   ON public.scan_history USING GIN (input_data);

-- blacklist
CREATE INDEX IF NOT EXISTS idx_bl_account_id    ON public.blacklist(account_id);
CREATE INDEX IF NOT EXISTS idx_bl_active        ON public.blacklist(is_active);
CREATE INDEX IF NOT EXISTS idx_bl_added_by      ON public.blacklist(added_by);


-- ─────────────────────────────────────────────
--  TRIGGER: auto-update updated_at
-- ─────────────────────────────────────────────
CREATE OR REPLACE FUNCTION public.set_updated_at()
RETURNS TRIGGER LANGUAGE plpgsql AS $$
BEGIN
    NEW.updated_at = NOW();
    RETURN NEW;
END;
$$;

CREATE OR REPLACE TRIGGER trg_users_updated_at
    BEFORE UPDATE ON public.users
    FOR EACH ROW EXECUTE FUNCTION public.set_updated_at();

CREATE OR REPLACE TRIGGER trg_blacklist_updated_at
    BEFORE UPDATE ON public.blacklist
    FOR EACH ROW EXECUTE FUNCTION public.set_updated_at();

CREATE OR REPLACE TRIGGER trg_api_config_updated_at
    BEFORE UPDATE ON public.api_config
    FOR EACH ROW EXECUTE FUNCTION public.set_updated_at();


-- ─────────────────────────────────────────────
--  ROW LEVEL SECURITY (RLS) — Supabase
-- ─────────────────────────────────────────────

-- Bật RLS trên tất cả bảng
ALTER TABLE public.users        ENABLE ROW LEVEL SECURITY;
ALTER TABLE public.scan_history ENABLE ROW LEVEL SECURITY;
ALTER TABLE public.blacklist    ENABLE ROW LEVEL SECURITY;
ALTER TABLE public.api_config   ENABLE ROW LEVEL SECURITY;

-- Helper function: lấy role của user đang đăng nhập
CREATE OR REPLACE FUNCTION public.current_user_role()
RETURNS user_role LANGUAGE sql STABLE SECURITY DEFINER AS $$
    SELECT role FROM public.users WHERE auth_id = auth.uid() LIMIT 1;
$$;

-- ── users ──
-- User chỉ xem được profile của chính mình
CREATE POLICY "users_select_own"
    ON public.users FOR SELECT
    USING (auth_id = auth.uid());

-- Admin xem tất cả
CREATE POLICY "admin_select_all_users"
    ON public.users FOR SELECT
    USING (public.current_user_role() = 'admin');

-- Chỉ admin mới được update role
CREATE POLICY "admin_update_users"
    ON public.users FOR UPDATE
    USING (public.current_user_role() = 'admin');

-- User tự update profile của chính mình (trừ role)
CREATE POLICY "users_update_own_profile"
    ON public.users FOR UPDATE
    USING (auth_id = auth.uid())
    WITH CHECK (role = (SELECT role FROM public.users WHERE auth_id = auth.uid()));

-- ── scan_history ──
-- User xem lịch sử của chính mình
CREATE POLICY "users_select_own_scans"
    ON public.scan_history FOR SELECT
    USING (scanned_by IN (SELECT id FROM public.users WHERE auth_id = auth.uid()));

-- Admin xem tất cả
CREATE POLICY "admin_select_all_scans"
    ON public.scan_history FOR SELECT
    USING (public.current_user_role() = 'admin');

-- Mọi user đều có thể INSERT scan mới
CREATE POLICY "users_insert_scan"
    ON public.scan_history FOR INSERT
    WITH CHECK (
        scanned_by IN (SELECT id FROM public.users WHERE auth_id = auth.uid())
    );

-- Chỉ admin được xóa (không ai được UPDATE — audit trail)
CREATE POLICY "admin_delete_scan"
    ON public.scan_history FOR DELETE
    USING (public.current_user_role() = 'admin');

-- ── blacklist ──
-- Tất cả user đều đọc được blacklist (cần để validate trước khi scan)
CREATE POLICY "all_select_blacklist"
    ON public.blacklist FOR SELECT
    USING (TRUE);

-- Chỉ admin INSERT/UPDATE/DELETE blacklist
CREATE POLICY "admin_manage_blacklist"
    ON public.blacklist FOR ALL
    USING (public.current_user_role() = 'admin');

-- ── api_config ──
-- Tất cả user đọc được (cần lấy ngrok URL)
CREATE POLICY "all_select_config"
    ON public.api_config FOR SELECT
    USING (TRUE);

-- Chỉ admin sửa config
CREATE POLICY "admin_manage_config"
    ON public.api_config FOR ALL
    USING (public.current_user_role() = 'admin');


-- ─────────────────────────────────────────────
--  VIEWS (tiện lợi cho WinForms queries)
-- ─────────────────────────────────────────────

-- View: lịch sử scan kèm tên người thực hiện
CREATE OR REPLACE VIEW public.v_scan_history AS
SELECT
    sh.id,
    sh.account_name,
    sh.prediction,
    sh.confidence,
    sh.prob_spam,
    sh.prob_real,
    sh.scan_source,
    sh.note,
    sh.created_at,
    u.username   AS scanned_by_username,
    u.role       AS scanned_by_role,
    -- Flag: tài khoản này có trong blacklist không?
    EXISTS (
        SELECT 1 FROM public.blacklist bl
        WHERE bl.account_name = sh.account_name AND bl.is_active = TRUE
    ) AS is_blacklisted
FROM public.scan_history sh
LEFT JOIN public.users u ON u.id = sh.scanned_by;

-- View: thống kê tổng hợp cho UC06 (Dashboard)
CREATE OR REPLACE VIEW public.v_statistics AS
SELECT
    COUNT(*)                                             AS total_scans,
    COUNT(*) FILTER (WHERE prediction = 'spam')         AS total_spam,
    COUNT(*) FILTER (WHERE prediction = 'real')         AS total_real,
    ROUND(AVG(confidence)::NUMERIC, 4)                  AS avg_confidence,
    COUNT(*) FILTER (WHERE scan_source = 'batch_csv')   AS batch_scans,
    COUNT(*) FILTER (WHERE scan_source = 'single')      AS single_scans,
    COUNT(*) FILTER (
        WHERE created_at >= NOW() - INTERVAL '24 hours'
    )                                                   AS scans_last_24h,
    (SELECT COUNT(*) FROM public.blacklist WHERE is_active = TRUE) AS active_blacklist_count
FROM public.scan_history;


-- ─────────────────────────────────────────────
--  STORED PROCEDURES
-- ─────────────────────────────────────────────

-- Procedure: thêm vào blacklist từ một scan_history record
CREATE OR REPLACE FUNCTION public.promote_to_blacklist(
    p_scan_id       UUID,
    p_reason        TEXT DEFAULT NULL,
    p_admin_id      UUID DEFAULT NULL
)
RETURNS UUID LANGUAGE plpgsql SECURITY DEFINER AS $$
DECLARE
    v_account_name  VARCHAR(150);
    v_confidence    NUMERIC(5,4);
    v_new_id        UUID;
BEGIN
    -- Lấy thông tin từ scan
    SELECT account_name, confidence
    INTO   v_account_name, v_confidence
    FROM   public.scan_history
    WHERE  id = p_scan_id;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Scan ID không tồn tại: %', p_scan_id;
    END IF;

    -- Upsert vào blacklist
    INSERT INTO public.blacklist (
        account_name, reason, confidence_at_add, source_scan_id, added_by
    ) VALUES (
        v_account_name,
        COALESCE(p_reason, 'Promoted from scan result'),
        v_confidence,
        p_scan_id,
        p_admin_id
    )
    ON CONFLICT (account_id) DO UPDATE
        SET is_active          = TRUE,
            reason             = EXCLUDED.reason,
            confidence_at_add  = EXCLUDED.confidence_at_add,
            source_scan_id     = EXCLUDED.source_scan_id,
            updated_at         = NOW()
    RETURNING id INTO v_new_id;

    RETURN v_new_id;
END;
$$;

COMMENT ON FUNCTION public.promote_to_blacklist IS
    'Chuyển kết quả scan thành blacklist entry. Idempotent (upsert).';


-- ─────────────────────────────────────────────
--  GRANT PERMISSIONS (Supabase service role)
-- ─────────────────────────────────────────────
GRANT USAGE ON SCHEMA public TO anon, authenticated;
GRANT SELECT ON public.v_scan_history  TO authenticated;
GRANT SELECT ON public.v_statistics    TO authenticated;
GRANT EXECUTE ON FUNCTION public.promote_to_blacklist TO authenticated;


-- ─────────────────────────────────────────────
--  SEED DATA — tài khoản admin mẫu
--  THAY THẾ auth_id bằng UUID thật từ Supabase Auth
-- ─────────────────────────────────────────────
/*
INSERT INTO public.users (auth_id, username, display_name, role)
VALUES ('00000000-0000-0000-0000-000000000001', 'admin', 'System Administrator', 'admin')
ON CONFLICT (auth_id) DO NOTHING;
*/


-- ─────────────────────────────────────────────
--  KIỂM TRA SCHEMA (chạy để verify)
-- ─────────────────────────────────────────────
/*
SELECT table_name, row_security
FROM   information_schema.tables t
JOIN   pg_class c ON c.relname = t.table_name
WHERE  table_schema = 'public'
ORDER  BY table_name;

SELECT indexname, tablename FROM pg_indexes WHERE schemaname = 'public';

SELECT routine_name FROM information_schema.routines
WHERE  routine_schema = 'public' AND routine_type = 'FUNCTION';
*/
