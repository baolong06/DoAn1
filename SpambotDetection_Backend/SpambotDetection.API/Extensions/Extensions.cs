using System.Security.Claims;
using SpambotDetection.API.DTOs;
using SpambotDetection.Core.Interfaces;

namespace SpambotDetection.API.Extensions;

public static class ClaimsPrincipalExtensions
{
    /// <summary>
    /// Lấy internal public.users.id từ claim "internal_id".
    /// Claim này được add trong OnTokenValidated sau khi query DB theo auth_id.
    /// </summary>
    public static Guid? GetUserId(this ClaimsPrincipal principal)
    {
        // Ưu tiên internal_id (public.users.id) để dùng cho foreign key
        var internalId = principal.FindFirstValue("internal_id");
        if (Guid.TryParse(internalId, out var id)) return id;

        // Fallback: sub (Supabase auth_id) — chỉ dùng khi chưa có internal_id
        var sub = principal.FindFirstValue("sub");
        return Guid.TryParse(sub, out var authId) ? authId : null;
    }

    public static bool IsAdmin(this ClaimsPrincipal principal)
        => principal.IsInRole("admin");
}

public static class FeatureInputExtensions
{
    public static AccountFeatureInput ToFeatureInput(this AccountFeaturesRequest r) => new(
        r.FollowersCount, r.FriendsCount, r.StatusesCount, r.ListedCount,
        r.FavouritesCount, r.Verified, r.DefaultProfile, r.DefaultProfileImage,
        r.GeoEnabled, r.AccountAgeDays, r.NameLength, r.DescLength
    );
}