using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using FastConnectFootballSystem.Configuration.Dto;

namespace FastConnectFootballSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FastConnectFootballSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
