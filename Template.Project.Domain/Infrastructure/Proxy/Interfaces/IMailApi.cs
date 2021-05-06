using Template.Project.Domain.Infrastructure.Proxy.Models;
using System.Threading.Tasks;

namespace Template.Project.Domain.Infrastructure.Proxy.Interfaces
{
    public interface IMailApi
    {
        Task<bool> SendMailMessage(MailModel mailModel);
    }
}
