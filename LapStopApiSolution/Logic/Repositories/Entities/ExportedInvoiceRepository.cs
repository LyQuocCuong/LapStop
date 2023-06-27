namespace Repositories.Entities
{
    internal sealed class ExportedInvoiceRepository : AbstractEntityRepository<ExportedInvoice>, IExportedInvoiceRepository
    {
        public ExportedInvoiceRepository(EntityRepositoryParams repoParams) : base(repoParams)
        {
        }
    }
}
