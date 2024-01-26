using Abp.Application.Services;
using FastConnectFootballSystem.MultiTenancy.Dto;

namespace FastConnectFootballSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

