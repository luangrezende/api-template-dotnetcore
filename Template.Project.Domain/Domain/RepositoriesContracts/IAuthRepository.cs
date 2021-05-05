using Template.Project.Domain.Application.Dtos.Requests;
using Template.Project.Domain.Domain.Models;
using System.Threading.Tasks;

namespace Template.Project.Domain.Domain.RepositoriesContracts
{
    public interface IAuthRepository
    {
        Task<TokenEntity> GetToken(AuthReadRequest authReadRequest);
    }
}
