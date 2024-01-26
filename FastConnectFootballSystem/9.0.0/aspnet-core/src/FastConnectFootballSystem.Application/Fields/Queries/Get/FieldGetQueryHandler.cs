using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using FastConnectFootballSystem.Fields.Dto;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FastConnectFootballSystem.Fields.Queries.Get;

public class FieldGetQueryHandler : IRequestHandler<FieldGetQuery, FieldEditDto>
{
    private readonly IRepository<Field, Guid> _fieldRepository;
    private readonly IObjectMapper _mapper;

    public FieldGetQueryHandler(IRepository<Field, Guid> fieldRepository, IObjectMapper mapper)
    {
        _fieldRepository = fieldRepository;
        _mapper = mapper;
    }

    public async Task<FieldEditDto> Handle(FieldGetQuery request, CancellationToken cancellationToken)
    {
        var field = await _fieldRepository.GetAsync(request.Id);

        return _mapper.Map<FieldEditDto>(field);
    }
}
