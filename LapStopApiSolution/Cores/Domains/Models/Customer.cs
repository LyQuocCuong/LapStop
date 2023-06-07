namespace Domains.Models
{
    public sealed class Customer : BaseModel
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        #region NAVIGATION PROPERTIES

        public CustomerAccount? CustomerAccount { get; set; }

        public Cart? Cart { get; set; }

        public ICollection<SalesOrder>? SalesOrders { get; set; }

        #endregion
    }
}
