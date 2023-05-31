using Common.Models.Exceptions;
using Contracts.ILog;
using Contracts.IMapping;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;

namespace Services.Models
{
    internal sealed class InvoiceStatusService : ServiceBase, IInvoiceStatusService
    {
        public InvoiceStatusService(ILogService logService,
                               IMappingService mappingService,
                               IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }

        public async Task<IEnumerable<InvoiceStatusDto>> GetAllAsync()
        {
            IEnumerable<InvoiceStatus> invoiceStatuses = await _repositoryManager.InvoiceStatus.GetAllAsync(isTrackChanges: false);
            return _mappingService.Map<IEnumerable<InvoiceStatus>, IEnumerable<InvoiceStatusDto>>(invoiceStatuses);
        }

        public async Task<InvoiceStatusDto?> GetOneByIdAsync(Guid invoiceStatusId)
        {
            InvoiceStatus? invoiceStatus = await _repositoryManager.InvoiceStatus.GetOneByIdAsync(isTrackChanges: false, invoiceStatusId);
            if (invoiceStatus == null)
            {
                throw new ExNotFoundInDBModel(nameof(InvoiceStatusService), nameof(GetOneByIdAsync), typeof(InvoiceStatus), invoiceStatusId);
            }
            return _mappingService.Map<InvoiceStatus, InvoiceStatusDto>(invoiceStatus);
        }
    }
}
