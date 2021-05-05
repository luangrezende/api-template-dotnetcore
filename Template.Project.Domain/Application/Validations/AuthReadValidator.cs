using Template.Project.Domain.Application.Dtos.Requests;
using FluentValidation;

namespace Template.Project.Domain.Application.Validations
{
    class AuthReadValidator : AbstractValidator<AuthReadRequest>
    {
        public AuthReadValidator()
        {
            RuleFor(p => p.Username).NotEmpty().NotNull();
            RuleFor(p => p.Password).NotEmpty().NotNull();
        }
    }
}