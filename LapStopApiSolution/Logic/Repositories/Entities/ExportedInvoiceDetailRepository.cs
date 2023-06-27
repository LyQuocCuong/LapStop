namespace Repositories.Entities
{
    internal sealed class ExportedInvoiceDetailRepository : AbstractEntityRepository<ExportedInvoiceDetail>, IExportedInvoiceDetailRepository
    {
        public ExportedInvoiceDetailRepository(LapStopContext context, IDomainRepositories domainRepositories) : base(context, domainRepositories)
        {
        }
    }
}
