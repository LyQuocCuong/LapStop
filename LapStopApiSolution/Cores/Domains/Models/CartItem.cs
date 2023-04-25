using Domains.Base;

namespace Domains.Models
{
    public sealed class CartItem : BaseModel
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
