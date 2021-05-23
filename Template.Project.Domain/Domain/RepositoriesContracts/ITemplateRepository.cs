using Template.Project.Domain.RepositoriesContracts.IBase;
using Template.Project.Domain.Domain.Entities;

namespace Template.Project.Domain.Domain.RepositoriesContracts
{
    public interface ITemplateRepository : IBaseRepository<TemplateEntity, long>
    {
    }
}
