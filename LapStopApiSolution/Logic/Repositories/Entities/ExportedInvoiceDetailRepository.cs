namespace Repositories.Entities
{
    internal sealed class ExportedInvoiceDetailRepository : AbstractEntityRepository<ExportedInvoiceDetail>, IExportedInvoiceDetailRepository
    {
        public ExportedInvoiceDetailRepository(EntityRepositoryParams repoParams) : base(repoParams)
        {
        }
    }
}
