using Template.Project.Util.Enum;

namespace Template.Project.Domain.Infrastructure.Proxy.Models
{
    public class MailModel
    {
        public string Link { get; set; }

        public long UserId { get; set; }

        public TemplateMailEnum TemplateMailEnum { get; set; }
    }
}
