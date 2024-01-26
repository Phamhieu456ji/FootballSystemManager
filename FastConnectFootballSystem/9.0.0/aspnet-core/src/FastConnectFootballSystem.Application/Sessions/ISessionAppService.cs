using System.Threading.Tasks;
using Abp.Application.Services;
using FastConnectFootballSystem.Sessions.Dto;

namespace FastConnectFootballSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
