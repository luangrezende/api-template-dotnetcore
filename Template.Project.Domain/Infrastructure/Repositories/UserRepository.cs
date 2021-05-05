using Template.Project.Domain.Domain.RepositoriesContracts;
using Template.Project.Domain.RepositoriesContracts.IBase;
using Template.Project.Domain.Application.Dtos.Requests;
using Template.Project.Infrastructure.Repositories.Base;
using Template.Project.Domain.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Template.Project.Domain.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<UserEntity, long>, IUserRepository
    {
        private readonly ISystemContext _context;

        public UserRepository(ISystemContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> GetByCredentialsAsync(AuthReadRequest authReadRequest)
        {
            return await _context.Db.Set<UserEntity>()
                .FirstOrDefaultAsync(x => x.Username == authReadRequest.Username && x.Password == authReadRequest.Password);
        }
    }
}
