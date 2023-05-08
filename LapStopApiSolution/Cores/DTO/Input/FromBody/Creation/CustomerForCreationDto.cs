using System.ComponentModel.DataAnnotations;

namespace DTO.Input.FromBody.Creation
{
    public sealed class CustomerForCreationDto
    {
        [Required(ErrorMessage = "a required field")]
        [MaxLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "a required field")]
        [MaxLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string? LastName { get; set; }

        public string? Address { get; set; }

        [Required(ErrorMessage = "a required field")]
        [Phone]
        public string? Phone { get; set; }
    }
}
