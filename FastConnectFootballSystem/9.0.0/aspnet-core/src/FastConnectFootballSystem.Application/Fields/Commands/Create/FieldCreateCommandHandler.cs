using Abp.Domain.Repositories;
using Abp.UI;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FastConnectFootballSystem.Fields.Commands.Create;

public class FieldCreateCommandHandler : IRequestHandler<FieldCreateCommand>
{
    private readonly IRepository<Field, Guid> _repository;

    public FieldCreateCommandHandler(IRepository<Field, Guid> repository)
    {
        _repository = repository;
    }

    public async Task Handle(FieldCreateCommand request, CancellationToken cancellationToken)
    {
        await ValidateCreateAsync(request.Name);

        var field = Field.Create(request.Name, request.Status);

        await _repository.InsertAsync(field);
    }

    private async Task ValidateCreateAsync(string name)
    {
        var test = await _repository.GetAll().ToListAsync();
        var isExist = await _repository.GetAll()
            .AnyAsync(e => e.FieldName == name);

        if (isExist)
        {
            throw new UserFriendlyException("NameAlreadyExists");
        }
    }
}
