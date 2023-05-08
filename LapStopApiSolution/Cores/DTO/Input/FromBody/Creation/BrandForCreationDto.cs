using System.ComponentModel.DataAnnotations;

namespace DTO.Input.FromBody.Creation
{
    public sealed class BrandForCreationDto
    {
        [Required(ErrorMessage = "a required field")]
        [MaxLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "a required field")]
        [MaxLength(100, ErrorMessage = "Maximum length is 30 characters.")]
        public string? Description { get; set; }

        public string? AvatarUrl { get; set; }
    }
}
