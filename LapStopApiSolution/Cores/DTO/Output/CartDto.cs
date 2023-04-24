using DTO.Base;

namespace DTO.Output
{
    public sealed class CartDto : OutputBaseDto
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public int Total { get; set; }
    }
}
