using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapStopApi.Entities.Models
{
    public sealed class ImportedInvoiceDetail
    {
        public Guid Id { get; set; }

        public Guid ImportedInvoiceId { get; set; }

        public Guid ProductId { get; set; }

        public string ProductBarcode { get; set; }

        public int CostPrice { get; set; }

        public int Quantity { get; set; }

        public int SubTotal { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        #region NAVIGATION PROPERTIES

        public ImportedInvoice ImportedInvoice { get; set; }

        public Product Product { get; set; }
 
        #endregion
    }
}
