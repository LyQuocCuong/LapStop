namespace Repositories.Entities
{
    internal sealed class ImportedInvoiceDetailRepository : AbstractEntityRepository<ImportedInvoiceDetail>, IImportedInvoiceDetailRepository
    {
        public ImportedInvoiceDetailRepository(LapStopContext context, IDomainRepositories domainRepositories) : base(context, domainRepositories)
        {
        }
    }
}
