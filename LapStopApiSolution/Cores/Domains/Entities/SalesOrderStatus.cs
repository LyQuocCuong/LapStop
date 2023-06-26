namespace Domains.Entities
{
    public sealed class SalesOrderStatus : BaseEntity
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool IsEnable { get; set; }

        #region NAVIGATION PROPERTIES

        public ICollection<SalesOrder>? SalesOrders { get; set; }

        #endregion
    }
}
