using Domains.Base;

namespace Domains.Models
{
    public sealed class Cart : BaseModel
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public int Total { get; set; }

        #region NAVIGATION PROPERTIES

        public Customer? Customer { get; set; }

        public ICollection<CartItem>? CartItems { get; set; }

        #endregion

    }
}
