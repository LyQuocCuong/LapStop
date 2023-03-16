using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapStopApi.Entities.Models
{
    public sealed class ExportedInvoiceDetail
    {
        public Guid Id { get; set; }

        public Guid ExportedInvoiceId { get; set; }

        public Guid ProductId { get; set; }

        public string? ProductBarcode { get; set; }

        public int SellingPrice { get; set; }

        public int Quantity { get; set; }

        public int SubTotal { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        #region NAVIGATION PROPERTIES

        public ExportedInvoice? ExportedInvoice { get; set; }

        public Product? Product { get; set; }

        #endregion
    }
}
