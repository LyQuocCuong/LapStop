using DTO.Bases;

namespace DTO.Output.Data
{
    public sealed class SalesOrderStatusDto : BaseOutputDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool IsEnable { get; set; }
    }
}
