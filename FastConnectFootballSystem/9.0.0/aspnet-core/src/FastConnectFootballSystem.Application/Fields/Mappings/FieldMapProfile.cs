using AutoMapper;
using FastConnectFootballSystem.Fields.Commands.Create;
using FastConnectFootballSystem.Fields.Commands.Edit;
using FastConnectFootballSystem.Fields.Dto;

namespace FastConnectFootballSystem.Fields.Mappings;

public class FieldMapProfile : Profile
{
    public FieldMapProfile()
    {
        CreateMap<FieldListDto, Field>();

        CreateMap<Field, FieldListDto>();

        CreateMap<Field, FieldCreateDto>();

        CreateMap<FieldEditDto, Field>();

        CreateMap<Field, FieldEditDto>();

        CreateMap<FieldCreateCommand, Field>();

        CreateMap<FieldEditCommand, Field>();
    }
}
