namespace Domains.Entities
{
    public sealed class ExportedInvoiceDetail : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid ExportedInvoiceId { get; set; }

        public Guid ProductId { get; set; }

        public string? ProductBarcode { get; set; }

        public int SellingPrice { get; set; }

        public int Quantity { get; set; }

        public int SubTotal { get; set; }

        #region NAVIGATION PROPERTIES

        public ExportedInvoice? ExportedInvoice { get; set; }

        public Product? Product { get; set; }

        #endregion
    }
}
