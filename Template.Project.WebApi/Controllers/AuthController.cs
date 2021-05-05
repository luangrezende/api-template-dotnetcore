using Template.Project.Domain.Application.Services.Interfaces;
using Template.Project.Domain.Application.Dtos.Responses;
using Template.Project.Domain.Application.Dtos.Requests;
using Template.Project.Application.CustomExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace Template.Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
        [AllowAnonymous]
        [Route("Login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthReadRequest authReadRequest)
        {
            try
            {
                return Ok(await _authService.AuthAndGenerateToken(authReadRequest));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error on Auth - GenerateToken");
                return BadRequest(e.Message);
            }
        }
    }
}
