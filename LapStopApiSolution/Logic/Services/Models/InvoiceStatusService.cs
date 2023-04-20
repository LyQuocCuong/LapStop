using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;

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
            return _mapper.Map<List<InvoiceStatusDto>>(invoiceStatuses);
        }

        public InvoiceStatusDto? GetById(bool isTrackChanges, Guid id)
        {
            InvoiceStatus? invoiceStatus = _repositoryManager.InvoiceStatus.GetById(isTrackChanges, id);
            return _mapper.Map<InvoiceStatusDto>(invoiceStatus);
        }
    }
}
