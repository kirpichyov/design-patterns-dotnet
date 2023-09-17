namespace DesignPatterns.Common.Contracts;

public interface IAuthContext
{
    Guid GetCurrentUserId();
    bool EnsureUserHasOrdersViewPermission();
}