namespace Domains.Entities
{
    public sealed class CustomerAccount : BaseEntity
    {
        public Guid CustomerId { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool IsActivate { get; set; }

        #region NAVIGATION PROPERTIES

        public Customer? Customer { get; set; }

        #endregion

    }
}
