using Template.Project.Domain.Application.Services.Interfaces;
using Template.Project.Domain.Domain.RepositoriesContracts;
using Template.Project.Domain.Application.Dtos.Responses;
using Template.Project.Domain.Application.Dtos.Requests;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using System;

namespace Template.Project.Domain.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AuthService(IAuthRepository authRepository, IConfiguration configuration, IMapper mapper, ILogger<AuthService> logger)
        {
            _authRepository = authRepository;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TokenResponse> GenerateToken(UserResponse userResponse)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Authentication").GetSection("Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userResponse.Name),
                    new Claim(ClaimTypes.Role, userResponse.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenResponse = new TokenResponse
            {
                Token = tokenHandler.WriteToken(token)
            };

            return tokenResponse;
        }

        public async Task<UserResponse> GetUser(AuthReadRequest authReadRequest)
        {
            return new UserResponse 
            {
                Name =  "batman",
                Username =  "batman",
                Role = "admin"
            };
        }
    }
}
