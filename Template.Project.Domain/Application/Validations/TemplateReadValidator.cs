using Template.Project.Domain.Application.Dtos.Requests;
using FluentValidation;

namespace Template.Project.Domain.Application.Validations
{
    public class TemplateReadValidator : AbstractValidator<TemplateReadRequest>
    {
        public TemplateReadValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull();
            RuleFor(p => p.Number).NotEmpty().NotNull();
        }
    }
}
