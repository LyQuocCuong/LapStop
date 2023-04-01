using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class ExportedInvoice
    {
        public Guid Id { get; set; }

        public Guid SalesOrderId { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid InvoiceStatusId { get; set; }

        public string? InvoiceCode { get; set; }

        public DateTime InvoiceDate { get; set; }

        public int Total { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        #region NAVIGATION PROPERTIES

        public Employee? Employee { get; set; }

        public SalesOrder? SalesOrder { get; set; }

        public InvoiceStatus? InvoiceStatus { get; set; }

        public ICollection<ExportedInvoiceDetail>? ExportedInvoiceDetails { get; set; }

        #endregion
    }
}
