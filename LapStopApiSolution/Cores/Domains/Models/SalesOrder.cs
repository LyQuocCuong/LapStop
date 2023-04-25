using Domains.Base;

namespace Domains.Models
{
    public sealed class SalesOrder : BaseModel
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Guid SalesOrderStatusId { get; set; }

        public DateTime OrderDate { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public int Total { get; set; }

        #region NAVIGATION PROPERTIES

        public Customer? Customer { get; set; }

        public SalesOrderStatus? SalesOrderStatus { get; set; }

        public ExportedInvoice? ExportedInvoice { get; set; }

        public ICollection<SalesOrderDetail>? SalesOrderDetails { get; set; }

        #endregion
    }
}
