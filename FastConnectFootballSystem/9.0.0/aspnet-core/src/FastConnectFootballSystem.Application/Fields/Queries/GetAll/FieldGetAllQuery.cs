using FastConnectFootballSystem.Fields.Dto;
using MediatR;
using System.Collections.Generic;

namespace FastConnectFootballSystem.Fields.Queries.GetAll;

public record FieldGetAllQuery(string searchTerm) : IRequest<List<FieldListDto>>;
