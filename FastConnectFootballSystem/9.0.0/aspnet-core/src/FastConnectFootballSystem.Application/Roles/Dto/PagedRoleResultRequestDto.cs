using Abp.Application.Services.Dto;

namespace FastConnectFootballSystem.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

