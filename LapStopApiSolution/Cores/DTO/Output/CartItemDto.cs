using DTO.Base;

namespace DTO.Output
{
    public sealed class CartItemDto : OutputBaseDto
    {
        public Guid Id { get; set; }

        public Guid CartId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public int SellingPrice { get; set; }

        public int SubTotal { get; set; }
    }
}
