namespace Repositories.Entities
{
    internal sealed class ImportedInvoiceRepository : AbstractEntityRepository<ImportedInvoice>, IImportedInvoiceRepository
    {
        public ImportedInvoiceRepository(LapStopContext context, IDomainRepositories domainRepositories) : base(context, domainRepositories)
        {
        }
    }
}
