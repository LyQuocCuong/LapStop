using DTO.Bases;

namespace DTO.Output.Data
{
    public sealed class CartDto : BaseOutputDto
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public int Total { get; set; }
    }
}
