﻿using AutoMapper;
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

        public List<SalesOrderStatusDto> GetAll(bool isTrackChanges)
        {
            List<SalesOrderStatus> salesOrderStatuses = _repositoryManager.SalesOrderStatus.GetAll(isTrackChanges);
            return MappingToNewObj<List<SalesOrderStatusDto>>(salesOrderStatuses);
        }

        public SalesOrderStatusDto? GetById(bool isTrackChanges, Guid id)
        {
            SalesOrderStatus? salesOrderStatus = _repositoryManager.SalesOrderStatus.GetById(isTrackChanges, id);
            if (salesOrderStatus == null)
            {
                throw new ExNotFoundInDB(nameof(SalesOrderStatusService), nameof(GetById), typeof(SalesOrderStatus), id);
            }
            return MappingToNewObj<SalesOrderStatusDto>(salesOrderStatus);
        }
    }
}
