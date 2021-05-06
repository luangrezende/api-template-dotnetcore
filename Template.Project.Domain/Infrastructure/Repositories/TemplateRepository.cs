using Template.Project.Domain.Domain.RepositoriesContracts;
using Template.Project.Domain.RepositoriesContracts.IBase;
using Template.Project.Infrastructure.Repositories.Base;
using Template.Project.Domain.Application.Dtos.Requests;
using Template.Project.Domain.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template.Project.Domain.Infrastructure.Repositories
{
    public class TemplateRepository : BaseRepository<TemplateEntity, long>, ITemplateRepository
    {
        private readonly ISystemContext _context;

        public TemplateRepository(ISystemContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<TemplateEntity>> GetAllFromTemplateAsync(TemplateReadRequest templateReadRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
