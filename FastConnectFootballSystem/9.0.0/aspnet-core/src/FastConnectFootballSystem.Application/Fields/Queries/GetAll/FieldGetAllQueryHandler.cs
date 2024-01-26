using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using FastConnectFootballSystem.Fields.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FastConnectFootballSystem.Fields.Queries.GetAll;

public class FieldGetAllQueryHandler : IRequestHandler<FieldGetAllQuery, List<FieldListDto>>
{
    private readonly IRepository<Field, Guid> _fieldRepository;

    public FieldGetAllQueryHandler(IRepository<Field, Guid> fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }

    public async Task<List<FieldListDto>> Handle(FieldGetAllQuery request, CancellationToken cancellationToken)
    {
        var fields = await _fieldRepository.GetAll()
            .WhereIf(!request.searchTerm.IsNullOrEmpty(),
                     e => EF.Functions.Collate(e.FieldName, "SQL_Latin1_General_Cp1_CI_AI").Contains(request.searchTerm)
                     || EF.Functions.Collate(e.FieldStatus, "SQL_Latin1_General_Cp1_CI_AI").Contains(request.searchTerm))
            .Select(x => new
            {
                x.Id,
                x.FieldName,
                x.FieldStatus
            })
            .ToListAsync();

        return fields.ConvertAll(x => new FieldListDto(
            x.Id,
            x.FieldName,
            x.FieldStatus));
    }
}
