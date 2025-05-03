namespace api.Responses.UsersResponse
{
    public class UpdateUserResponse
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }
    }
}
