namespace Services.Entities
{
    internal sealed class ImportedInvoiceDetailService : AbstractService, IImportedInvoiceDetailService
    {
        public ImportedInvoiceDetailService(IDomainRepositories domainRepository,
                            IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
        {
        }
    }
}
