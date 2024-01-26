
using MediatR;

namespace FastConnectFootballSystem.Fields.Commands.Create;

public record FieldCreateCommand(string Name, string Status) : IRequest;
