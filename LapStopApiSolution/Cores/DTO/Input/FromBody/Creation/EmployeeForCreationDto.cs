using System.ComponentModel.DataAnnotations;

namespace DTO.Input.FromBody.Creation
{
    public class EmployeeForCreationDto
    {
        [Required(ErrorMessage = "a required field")]
        public Guid EmployeeRoleId { get; set; }

        [Required(ErrorMessage = "a required field")]
        public Guid EmployeeStatusId { get; set; }

        [Required(ErrorMessage = "a required field")]
        [MaxLength(10, ErrorMessage = "Maximum length is 10 characters.")]
        public string? EmployeeCode { get; set; }

        [Required(ErrorMessage = "a required field")]
        [MaxLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "a required field")]
        [MaxLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string? LastName { get; set; }

        public bool? IsMale { get; set; }

        public DateTime DOB { get; set; }

        public string? Address { get; set; }

        [Required(ErrorMessage = "a required field")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "a required field")]
        [Phone]
        public string? Phone { get; set; }

        public string? AvatarUrl { get; set; }
    }
}
