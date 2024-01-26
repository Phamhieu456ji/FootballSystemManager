using System.Threading.Tasks;
using FastConnectFootballSystem.Configuration.Dto;

namespace FastConnectFootballSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
