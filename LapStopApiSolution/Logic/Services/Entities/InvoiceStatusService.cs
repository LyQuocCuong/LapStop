﻿namespace Services.Entities
{
    internal sealed class InvoiceStatusService : AbstractService, IInvoiceStatusService
    {
        public InvoiceStatusService(IDomainRepositories domainRepository,
                            IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
        {
        }

        public async Task<IEnumerable<InvoiceStatusDto>> GetAllAsync()
        {
            IEnumerable<InvoiceStatus> invoiceStatuses = await EntityRepositories.InvoiceStatus.GetAllAsync(isTrackChanges: false);
            return UtilServices.Mapper.ExecuteMapping<IEnumerable<InvoiceStatus>, IEnumerable<InvoiceStatusDto>>(invoiceStatuses);
        }

        public async Task<InvoiceStatusDto?> GetOneByIdAsync(Guid invoiceStatusId)
        {
            InvoiceStatus? invoiceStatus = await EntityRepositories.InvoiceStatus.GetOneByIdAsync(isTrackChanges: false, invoiceStatusId);
            if (invoiceStatus == null)
            {
                throw new ExNotFoundInDBModel(nameof(InvoiceStatusService), nameof(GetOneByIdAsync), typeof(InvoiceStatus), invoiceStatusId);
            }
            return UtilServices.Mapper.ExecuteMapping<InvoiceStatus, InvoiceStatusDto>(invoiceStatus);
        }
    }
}
