namespace Domains.Models
{
    public sealed class SalesOrderDetail : BaseModel
    {
        public Guid Id { get; set; }

        public Guid SalesOrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public int SellingPrice { get; set; }

        public int SubTotal { get; set; }


        #region NAVIGATION PROPERTIES

        public SalesOrder? SalesOrder { get; set; }

        public Product? Product { get; set; }

        #endregion
    }
}
