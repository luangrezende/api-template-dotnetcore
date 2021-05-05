using Template.Project.Domain.Application.Services.Interfaces;
using Template.Project.Domain.Domain.RepositoriesContracts;
using Template.Project.Domain.Application.Dtos.Responses;
using Template.Project.Domain.Application.Dtos.Requests;
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

        public async Task<IEnumerable<TemplateResponse>> GetAllFromTemplateAsync(TemplateReadRequest templateReadRequest)
        {
            var template = 
                await _templateRepository.GetAllFromTemplateAsync(templateReadRequest);

            return _mapper.Map<IEnumerable<TemplateResponse>>(template);
        }
    }
}
