using Abp.Authorization;
using FastConnectFootballSystem.Authorization.Roles;
using FastConnectFootballSystem.Authorization.Users;

namespace FastConnectFootballSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
