using System.ComponentModel.DataAnnotations;

namespace Template.Project.Domain.Application.Dtos.Requests
{
    public class TemplateReadRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }
    }
}
