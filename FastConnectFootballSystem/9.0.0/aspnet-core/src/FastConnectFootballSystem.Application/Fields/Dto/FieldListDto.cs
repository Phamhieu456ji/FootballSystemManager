using System;

namespace FastConnectFootballSystem.Fields.Dto;

public record FieldListDto(
    Guid Id,
    string Name,
    string Status);
