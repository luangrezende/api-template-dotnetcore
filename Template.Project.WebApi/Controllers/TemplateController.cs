using Template.Project.Domain.Application.Services.Interfaces;
using Template.Project.Domain.Application.Dtos.Responses;
using Template.Project.Application.CustomExceptions;
using Microsoft.AspNetCore.Authorization;
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
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _templateService;
        private readonly ILogger _logger;

        public TemplateController(
            ITemplateService templateService,
            ILogger<TemplateController> logger)
        {
            _templateService = templateService;
            _logger = logger;
        }

        /// <summary>
        /// Get all from database
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TemplateResponse>>> Get()
        {
            try
            {
                return Ok(await _templateService.GetAllAsync());
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error on Template Controller - GetAllAsync");
                return BadRequest(e.Message);
            }
        }
    }
}
