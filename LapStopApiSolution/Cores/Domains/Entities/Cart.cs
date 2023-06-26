namespace Domains.Entities
{
    public sealed class Cart : BaseEntity
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
