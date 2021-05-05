namespace Template.Project.Domain.Application.Dtos.Responses
{
    public class AuthResponse
    {
        public UserResponse User { get; set; }

        public TokenResponse Token { get; set; }
    }
}
