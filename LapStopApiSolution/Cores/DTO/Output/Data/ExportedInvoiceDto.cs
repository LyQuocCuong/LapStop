using DTO.Bases;

namespace DTO.Output.Data
{
    public sealed class ExportedInvoiceDto : BaseOutputDto
    {
        public Guid Id { get; set; }

        public Guid SalesOrderId { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid InvoiceStatusId { get; set; }

        public string? InvoiceCode { get; set; }

        public DateTime InvoiceDate { get; set; }

        public int Total { get; set; }
    }
}
