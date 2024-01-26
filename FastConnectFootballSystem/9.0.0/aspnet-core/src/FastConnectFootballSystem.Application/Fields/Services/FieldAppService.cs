using Abp.Authorization;
using FastConnectFootballSystem.Fields.Commands.Create;
using FastConnectFootballSystem.Fields.Commands.Delete;
using FastConnectFootballSystem.Fields.Commands.Edit;
using FastConnectFootballSystem.Fields.Dto;
using FastConnectFootballSystem.Fields.Queries.Get;
using FastConnectFootballSystem.Fields.Queries.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastConnectFootballSystem.Fields.Services
{
    public class FieldAppService : FastConnectFootballSystemAppServiceBase, IFieldAppService
    {
        private readonly ISender _sender;

        public FieldAppService(ISender sender)
        {
            _sender = sender;
        }

        public async Task Create(FieldCreateDto input)
        {
            var command = new FieldCreateCommand(input.Name, input.Status);

            await _sender.Send(command);
        }

        public async Task Delete(Guid Id)
        {
            var command = new FieldDeleteCommand(Id);

            await _sender.Send(command);
        }

        public async Task Edit(FieldEditDto input)
        {
            var command = new FieldEditCommand(
                input.Id,
                input.Name,
                input.Status);

            await _sender.Send(command);
        }

        public async Task<List<FieldListDto>> GetAll(FieldGetAllDto input)
        {
            return await _sender.Send(new FieldGetAllQuery(input.searchTerm));
        }

        public Task<FieldEditDto> Get(Guid Id)
        {
            return _sender.Send(new FieldGetQuery(Id));
        }
    }
}
