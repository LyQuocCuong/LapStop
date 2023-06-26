namespace Services.Entities
{
    internal sealed class ImportedInvoiceService : AbstractService, IImportedInvoiceService
    {
        public ImportedInvoiceService(IDomainRepositories domainRepository,
                            IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
        {
        }
    }
}
