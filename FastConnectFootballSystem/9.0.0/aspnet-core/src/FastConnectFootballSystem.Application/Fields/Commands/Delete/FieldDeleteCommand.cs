
using MediatR;
using System;

namespace FastConnectFootballSystem.Fields.Commands.Delete;

public record FieldDeleteCommand(Guid Id) : IRequest;
