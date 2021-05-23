using Template.Project.Domain.Application.Dtos.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template.Project.Domain.Application.Services.Interfaces
{
    public interface ITemplateService
    {
        Task<IEnumerable<TemplateResponse>> GetAllAsync();
    }
}