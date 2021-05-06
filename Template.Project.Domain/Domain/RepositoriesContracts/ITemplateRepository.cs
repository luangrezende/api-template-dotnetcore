using Template.Project.Domain.RepositoriesContracts.IBase;
using Template.Project.Domain.Application.Dtos.Requests;
using Template.Project.Domain.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template.Project.Domain.Domain.RepositoriesContracts
{
    public interface ITemplateRepository : IBaseRepository<TemplateEntity, long>
    {
        Task<IEnumerable<TemplateEntity>> GetAllFromTemplateAsync(TemplateReadRequest templateReadRequest);
    }
}
