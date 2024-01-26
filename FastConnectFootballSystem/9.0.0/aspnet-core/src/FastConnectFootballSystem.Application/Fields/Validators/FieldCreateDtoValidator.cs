using FastConnectFootballSystem.Fields.Dto;
using FluentValidation;

namespace FastConnectFootballSystem.Fields.Validators
{
    public class FieldCreateDtoValidator : AbstractValidator<FieldCreateDto>
    {
        public FieldCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .MaximumLength(FieldConfiguration.NameMaxLength);

            RuleFor(x => x.Status).NotEmpty()
                .MaximumLength(FieldConfiguration.StatusMaxLength);
        }
    }
}
