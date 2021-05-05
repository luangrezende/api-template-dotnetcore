using Template.Project.Domain.Domain.RepositoriesContracts;
using Template.Project.Domain.RepositoriesContracts.IBase;
using Template.Project.Domain.Application.Dtos.Requests;
using Template.Project.Infrastructure.Repositories.Base;
using Template.Project.Application.CustomExceptions;
using Template.Project.Domain.Domain.Models;
using Template.Project.Util.Cryptograph;
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
            var user =
                await _context.Db.Set<UserEntity>()
                .FindAsync(authReadRequest.Username);

            return Crypt.PasswordVerify(authReadRequest.Password, user.Password)
                ? user
                : throw new NotFoundException("Invalid username or password");
        }
    }
}
