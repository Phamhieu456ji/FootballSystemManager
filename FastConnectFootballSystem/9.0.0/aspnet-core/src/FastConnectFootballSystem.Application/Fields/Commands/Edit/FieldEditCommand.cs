using MediatR;
using System;

namespace FastConnectFootballSystem.Fields.Commands.Edit;

public record FieldEditCommand(Guid Id, string Name, string Status) : IRequest;
