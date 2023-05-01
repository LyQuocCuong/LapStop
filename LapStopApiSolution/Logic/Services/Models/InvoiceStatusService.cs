using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class InvoiceStatusService : ServiceBase, IInvoiceStatusService
    {
        public InvoiceStatusService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<InvoiceStatusDto> GetAll(bool isTrackChanges)
        {
            List<InvoiceStatus> invoiceStatuses = _repositoryManager.InvoiceStatus.GetAll(isTrackChanges);
            return MappingToNewObj<List<InvoiceStatusDto>>(invoiceStatuses);
        }

        public InvoiceStatusDto? GetOneById(bool isTrackChanges, Guid invoiceStatusId)
        {
            InvoiceStatus? invoiceStatus = _repositoryManager.InvoiceStatus.GetOneById(isTrackChanges, invoiceStatusId);
            if (invoiceStatus == null)
            {
                throw new ExNotFoundInDB(nameof(InvoiceStatusService), nameof(GetOneById), typeof(InvoiceStatus), invoiceStatusId);
            }
            return MappingToNewObj<InvoiceStatusDto>(invoiceStatus);
        }
    }
}
