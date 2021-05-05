using Template.Project.Domain.Domain.RepositoriesContracts;
using Template.Project.Domain.RepositoriesContracts.IBase;
using Template.Project.Domain.Infrastructure.Repositories;
using Template.Project.Infrastructure.DBContext;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Project.CrossCutting.DI
{
    public static class Repository
    {
        public static IServiceCollection AddRepositories(this IServiceCollection repository)
        {
            repository.AddScoped<ISystemContext, DBContext>();
            repository.AddScoped<ITemplateRepository, TemplateRepository>();

            return repository;
        }
    }
}
