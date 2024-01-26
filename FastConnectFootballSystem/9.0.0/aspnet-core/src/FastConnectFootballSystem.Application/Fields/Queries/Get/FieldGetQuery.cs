using FastConnectFootballSystem.Fields.Dto;
using MediatR;
using System;

namespace FastConnectFootballSystem.Fields.Queries.Get;

public record FieldGetQuery(Guid Id) : IRequest<FieldEditDto>;
