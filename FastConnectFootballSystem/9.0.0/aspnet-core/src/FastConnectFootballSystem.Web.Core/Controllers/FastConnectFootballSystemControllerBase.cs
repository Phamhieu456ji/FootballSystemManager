using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace FastConnectFootballSystem.Controllers
{
    public abstract class FastConnectFootballSystemControllerBase: AbpController
    {
        protected FastConnectFootballSystemControllerBase()
        {
            LocalizationSourceName = FastConnectFootballSystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
