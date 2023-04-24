using DTO.Base;

namespace DTO.Output
{
    public sealed class EmployeeStatusDto : BaseOutputDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool IsEnable { get; set; }
    }
}
