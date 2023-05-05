using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class SalesOrderStatusService : ServiceBase, ISalesOrderStatusService
    {
        public SalesOrderStatusService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<SalesOrderStatusDto> GetAll()
        {
            List<SalesOrderStatus> salesOrderStatuses = _repositoryManager.SalesOrderStatus.GetAll(isTrackChanges: false);
            return MappingToNewObj<List<SalesOrderStatusDto>>(salesOrderStatuses);
        }

        public SalesOrderStatusDto? GetOneById(Guid salesOrderStatusId)
        {
            SalesOrderStatus? salesOrderStatus = _repositoryManager.SalesOrderStatus.GetOneById(isTrackChanges: false, salesOrderStatusId);
            if (salesOrderStatus == null)
            {
                throw new ExNotFoundInDB(nameof(SalesOrderStatusService), nameof(GetOneById), typeof(SalesOrderStatus), salesOrderStatusId);
            }
            return MappingToNewObj<SalesOrderStatusDto>(salesOrderStatus);
        }
    }
}
