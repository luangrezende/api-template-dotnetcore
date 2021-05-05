using Template.Project.Domain.Application.Services.Interfaces;
using Template.Project.Domain.Domain.RepositoriesContracts;
using Template.Project.Domain.Application.Dtos.Responses;
using Template.Project.Domain.Application.Dtos.Requests;
using Template.Project.Application.CustomExceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Template.Project.Util.Models;
using Template.Project.Util.Auth;
using System.Threading.Tasks;
using System.Text;
using AutoMapper;
using Template.Project.Domain.Domain.Models;

namespace Template.Project.Domain.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AuthService(IUserRepository userRepository, IConfiguration configuration, IMapper mapper, ILogger<AuthService> logger)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AuthResponse> AuthAndGenerateToken(AuthReadRequest authReadRequest)
        {
            UserResponse userResponse =
                await GetUser(authReadRequest);

            string secret =
                _configuration["Authentication:Secret"];

            UserResponseUtil userToUserUtil =
                _mapper.Map<UserResponseUtil>(userResponse);

            string tokenBuilded =
                TokenBuilder.BuildToken(userToUserUtil, secret);

            return new AuthResponse
            {
                User = userResponse,
                Token = new TokenResponse
                {
                    Token = tokenBuilded
                }
            };
        }

        private async Task<UserResponse> GetUser(AuthReadRequest authReadRequest)
        {
            //UserEntity user =
            //    await _userRepository.GetByCredentialsAsync(authReadRequest);

            //return _mapper.Map<UserResponse>(user);

            return new UserResponse
            {
                UserID = "batman999999",
                Name = "batman",
                Email = "batman@gmail.com",
                Username = "batman",
                Role = "Admin"
            };
        }
    }
}
