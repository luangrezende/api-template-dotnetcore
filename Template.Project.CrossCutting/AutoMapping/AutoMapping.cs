using Template.Project.Domain.Application.Dtos.Responses;
using Microsoft.Extensions.DependencyInjection;
using Template.Project.Domain.Domain.Entities;
using Template.Project.Util.Models;
using AutoMapper;

namespace Template.Project.CrossCutting.AutoMapping
{
    public static class AutoMapping
    {
        public static IServiceCollection AddAutoMapping(this IServiceCollection serviceDescriptors)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TemplateEntity, TemplateResponse>().ReverseMap();
                cfg.CreateMap<TemplateResponse, TemplateResponseUtil>().ReverseMap();

                cfg.CreateMap<UserEntity, UserResponse>().ReverseMap();
                cfg.CreateMap<UserResponse, UserResponseUtil>().ReverseMap();
            });
            
            IMapper mapper = config.CreateMapper();
            serviceDescriptors.AddSingleton(mapper);

            return serviceDescriptors;
        }
    }
}
