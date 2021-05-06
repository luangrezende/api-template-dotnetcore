using Template.Project.Domain.RepositoriesContracts.IBase;
using Template.Project.Domain.Application.Dtos.Requests;
using Template.Project.Domain.Domain.Entities;
using System.Threading.Tasks;

namespace Template.Project.Domain.Domain.RepositoriesContracts
{
    public interface IUserRepository : IBaseRepository<UserEntity, long>
    {
        Task<UserEntity> GetByCredentialsAsync(AuthReadRequest authReadRequest);
    }
}
