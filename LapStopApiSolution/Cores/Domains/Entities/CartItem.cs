namespace Domains.Entities
{
    public sealed class CartItem : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid CartId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public int SellingPrice { get; set; }

        public int SubTotal { get; set; }

        #region NAVIGATION PROPERTIES

        public Cart? Cart { get; set; }

        public Product? Product { get; set; }

        #endregion
    }
}
