using Template.Project.Domain.Domain.RepositoriesContracts;
using Template.Project.Domain.Application.Dtos.Requests;
using Template.Project.Domain.Domain.Models;
using System.Threading.Tasks;

namespace Template.Project.Domain.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public async Task<TokenEntity> GetToken(AuthReadRequest authReadRequest)
        {
            return new TokenEntity
            {
                Token = "test"
            };
        }
    }
}
