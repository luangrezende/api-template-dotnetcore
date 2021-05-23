using Template.Project.Domain.Application.Services.Interfaces;
using Template.Project.Domain.Domain.RepositoriesContracts;
using Template.Project.Domain.Application.Dtos.Responses;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace Template.Project.Domain.Application.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public TemplateService(ITemplateRepository templateRepository, IMapper mapper, ILogger<TemplateService> logger)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TemplateResponse>> GetAllAsync()
        {
            var template = 
                await _templateRepository.GetAllAsync();

            _logger.LogInformation("Get all users async");

            return _mapper.Map<IEnumerable<TemplateResponse>>(template);
        }
    }
}
