using System.ComponentModel.DataAnnotations;

namespace api.DTOs.AuthDTOs
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(20, ErrorMessage = "Username must be less than 20 characters.")]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(30, ErrorMessage = "Email must be less than 30 characters.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
