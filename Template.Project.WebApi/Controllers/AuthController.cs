using Template.Project.Domain.Application.Services.Interfaces;
using Template.Project.Domain.Application.Dtos.Responses;
using Template.Project.Domain.Application.Dtos.Requests;
using Template.Project.Application.CustomExceptions;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace Template.Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;
        private readonly ILogger _logger;

        public AuthController(
            IHttpContextAccessor httpContextAccessor,
            IAuthService authService,
            ILogger<AuthController> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
            _logger = logger;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthReadRequest authReadRequest)
        {
            // Recupera o usuário
            var user = await _authService.GetUser(authReadRequest);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = await _authService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new AuthResponse
            {
                User = user,
                Token = token
            };
        }
    }
}
