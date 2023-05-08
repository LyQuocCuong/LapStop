using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class InvoiceStatusService : ServiceBase, IInvoiceStatusService
    {
        public InvoiceStatusService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<InvoiceStatusDto>> GetAllAsync()
        {
            IEnumerable<InvoiceStatus> invoiceStatuses = await _repositoryManager.InvoiceStatus.GetAllAsync(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<InvoiceStatusDto>>(invoiceStatuses);
        }

        public async Task<InvoiceStatusDto?> GetOneByIdAsync(Guid invoiceStatusId)
        {
            InvoiceStatus? invoiceStatus = await _repositoryManager.InvoiceStatus.GetOneByIdAsync(isTrackChanges: false, invoiceStatusId);
            if (invoiceStatus == null)
            {
                throw new ExNotFoundInDB(nameof(InvoiceStatusService), nameof(GetOneByIdAsync), typeof(InvoiceStatus), invoiceStatusId);
            }
            return MappingToNewObj<InvoiceStatusDto>(invoiceStatus);
        }
    }
}
