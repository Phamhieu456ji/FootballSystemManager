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

namespace FastConnectFootballSystem.Fields.Commands.Edit;

public class FieldEditCommandHandler : IRequestHandler<FieldEditCommand>
{
    private readonly IRepository<Field, Guid> _fieldRepository;

    public FieldEditCommandHandler(IRepository<Field, Guid> fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }

    public async Task Handle(FieldEditCommand request, CancellationToken cancellationToken)
    {
        await ValidateEditAsync(request.Name, request.Id);

        var clinicService = await _fieldRepository.GetAsync(request.Id);

        clinicService.Update(request.Name, request.Status);

        await _fieldRepository.UpdateAsync(clinicService);
    }
    private async Task ValidateEditAsync(string name, Guid id)
    {
        var isExist = await _fieldRepository.GetAll()
            .Where(x => x.Id != id)
            .AnyAsync(e => e.FieldName == name);

        if (isExist)
        {
            throw new UserFriendlyException("NameAlreadyExists");
        }
    }
}
