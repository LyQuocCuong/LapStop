using DTO.Base;

namespace DTO.Output.Data
{
    public sealed class SalesOrderDetailDto : BaseOutputDto
    {
        public Guid Id { get; set; }

        public Guid SalesOrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public int SellingPrice { get; set; }

        public int SubTotal { get; set; }
    }
}
