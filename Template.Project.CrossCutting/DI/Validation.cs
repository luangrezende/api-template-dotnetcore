using Template.Project.Domain.Application.Dtos.Requests;
using Template.Project.Domain.Application.Validations;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Template.Project.CrossCutting.DI
{
    public static class ValidationRegister
    {
        public static IServiceCollection AddValidations(this IServiceCollection validate)
        {
            validate.AddTransient<IValidator<TemplateReadRequest>, TemplateReadValidator>();

            return validate;
        }
    }
}
