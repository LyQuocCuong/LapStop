namespace DTO.Input.FromBody.Creation
{
    public class EmployeeForCreationDto
    {
        public Guid EmployeeRoleId { get; set; }

        public Guid EmployeeStatusId { get; set; }

        public string? EmployeeCode { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool? IsMale { get; set; }

        public DateTime DOB { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? AvatarUrl { get; set; }
    }
}
