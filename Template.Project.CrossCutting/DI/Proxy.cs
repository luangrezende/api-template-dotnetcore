using Template.Project.Domain.Infrastructure.Proxy.Interfaces;
using Template.Project.Domain.Infrastructure.Proxy;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Project.CrossCutting.DI
{
    public static class Proxy
    {
        public static IServiceCollection AddProxies(this IServiceCollection proxy)
        {
            proxy.AddScoped<IMailProxy, MailProxy>();

            return proxy;
        }
    }
}
