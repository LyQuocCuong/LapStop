using System.ComponentModel.DataAnnotations;

namespace DTO.Input.FromBody.Authentication
{
    public sealed class EmployeeForAuthentDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
