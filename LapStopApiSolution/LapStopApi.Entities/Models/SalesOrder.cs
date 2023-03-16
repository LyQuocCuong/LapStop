using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapStopApi.Entities.Models
{
    public sealed class SalesOrder
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Guid SalesOrderStatusId { get; set; }

        public DateTime OrderDate { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public int Total { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        #region NAVIGATION PROPERTIES

        public SalesOrderStatus? SalesOrderStatus { get; set; }

        public ExportedInvoice? ExportedInvoice { get; set; }

        public ICollection<SalesOrderDetail>? SalesOrderDetails { get; set; }

        #endregion
    }
}
