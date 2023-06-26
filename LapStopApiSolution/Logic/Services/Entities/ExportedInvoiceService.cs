namespace Services.Entities
{
    internal sealed class ExportedInvoiceService : AbstractService, IExportedInvoiceService
    {
        public ExportedInvoiceService(IDomainRepositories domainRepository,
                            IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
        {
        }
    }
}
