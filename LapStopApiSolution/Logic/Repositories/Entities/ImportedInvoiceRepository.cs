namespace Repositories.Entities
{
    internal sealed class ImportedInvoiceRepository : AbstractEntityRepository<ImportedInvoice>, IImportedInvoiceRepository
    {
        public ImportedInvoiceRepository(EntityRepositoryParams repoParams) : base(repoParams)
        {
        }
    }
}
