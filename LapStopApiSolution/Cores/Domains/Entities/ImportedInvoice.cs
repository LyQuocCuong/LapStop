namespace Domains.Entities
{
    public sealed class ImportedInvoice : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid InvoiceStatusId { get; set; }

        public string? InvoiceCode { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public int Total { get; set; }

        #region NAVIGATION PROPERTIES

        public Employee? Employee { get; set; }

        public InvoiceStatus? InvoiceStatus { get; set; }

        public ICollection<ImportedInvoiceDetail>? ImportedInvoiceDetails { get; set; }

        #endregion
    }
}
