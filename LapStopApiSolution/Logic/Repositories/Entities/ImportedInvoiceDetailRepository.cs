namespace Repositories.Entities
{
    internal sealed class ImportedInvoiceDetailRepository : AbstractEntityRepository<ImportedInvoiceDetail>, IImportedInvoiceDetailRepository
    {
        public ImportedInvoiceDetailRepository(EntityRepositoryParams repoParams) : base(repoParams)
        {
        }
    }
}
