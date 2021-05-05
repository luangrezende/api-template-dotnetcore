using Template.Project.Domain.Application.Dtos.Responses;
using Template.Project.Domain.Application.Dtos.Requests;
using System.Threading.Tasks;

namespace Template.Project.Domain.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TokenResponse> GenerateToken(UserResponse userResponse);

        Task<UserResponse> GetUser(AuthReadRequest authReadRequest);
    }
}
