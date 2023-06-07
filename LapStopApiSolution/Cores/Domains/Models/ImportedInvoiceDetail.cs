namespace Domains.Models
{
    public sealed class ImportedInvoiceDetail : BaseModel
    {
        public Guid Id { get; set; }

        public Guid ImportedInvoiceId { get; set; }

        public Guid ProductId { get; set; }

        public string? ProductBarcode { get; set; }

        public int CostPrice { get; set; }

        public int Quantity { get; set; }

        public int SubTotal { get; set; }

        #region NAVIGATION PROPERTIES

        public ImportedInvoice? ImportedInvoice { get; set; }

        public Product? Product { get; set; }
 
        #endregion
    }
}
