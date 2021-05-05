using System.ComponentModel.DataAnnotations;

namespace Template.Project.Domain.Application.Dtos.Requests
{
    public class AuthReadRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
