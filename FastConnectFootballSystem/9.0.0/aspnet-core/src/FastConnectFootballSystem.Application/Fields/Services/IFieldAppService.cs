using Abp.Dependency;
using FastConnectFootballSystem.Fields.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastConnectFootballSystem.Fields.Services
{
    public interface IFieldAppService : ITransientDependency
    {
        Task<List<FieldListDto>> GetAll(FieldGetAllDto input);

        Task<FieldEditDto> Get(Guid Id);

        Task Create(FieldCreateDto input);

        Task Edit(FieldEditDto input);

        Task Delete(Guid Id);
    }
}
