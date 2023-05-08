using DTO.Base;

namespace DTO.Output.Data
{
    public sealed class EmployeeAccountDto : BaseOutputDto
    {
        public Guid EmployeeId { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool IsActivate { get; set; }
    }
}
