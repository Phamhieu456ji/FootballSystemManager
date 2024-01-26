using System;

namespace FastConnectFootballSystem.Fields.Dto;

public record FieldEditDto(
    Guid Id,
    string Name,
    string Status);
