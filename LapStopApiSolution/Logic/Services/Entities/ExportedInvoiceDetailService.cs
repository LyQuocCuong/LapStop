namespace Services.Entities
{
    internal sealed class ExportedInvoiceDetailService : AbstractService, IExportedInvoiceDetailService
    {
        public ExportedInvoiceDetailService(IDomainRepositories domainRepository,
                            IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
        {
        }
    }
}
