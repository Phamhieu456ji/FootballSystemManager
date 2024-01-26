using Abp.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FastConnectFootballSystem.Fields.Commands.Delete;

public class FieldDeleteCommandHandler : IRequestHandler<FieldDeleteCommand>
{
    private readonly IRepository<Field, Guid> _fieldRepository;

    public FieldDeleteCommandHandler(IRepository<Field, Guid> fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }

    public async Task Handle(FieldDeleteCommand request, CancellationToken cancellationToken)
    {
        await _fieldRepository.DeleteAsync(request.Id);
    }
}
