namespace Repositories.Entities
{
    internal sealed class ExportedInvoiceRepository : AbstractEntityRepository<ExportedInvoice>, IExportedInvoiceRepository
    {
        public ExportedInvoiceRepository(LapStopContext context, IDomainRepositories domainRepositories) : base(context, domainRepositories)
        {
        }
    }
}
