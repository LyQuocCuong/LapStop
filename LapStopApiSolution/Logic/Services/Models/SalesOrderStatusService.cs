﻿using AutoMapper;
using Common.Models.Exceptions;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;

namespace Services.Models
{
    internal sealed class SalesOrderStatusService : ServiceBase, ISalesOrderStatusService
    {
        public SalesOrderStatusService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<SalesOrderStatusDto>> GetAllAsync()
        {
            IEnumerable<SalesOrderStatus> salesOrderStatuses = await _repositoryManager.SalesOrderStatus.GetAllAsync(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<SalesOrderStatusDto>>(salesOrderStatuses);
        }

        public async Task<SalesOrderStatusDto?> GetOneByIdAsync(Guid salesOrderStatusId)
        {
            SalesOrderStatus? salesOrderStatus = await _repositoryManager.SalesOrderStatus.GetOneByIdAsync(isTrackChanges: false, salesOrderStatusId);
            if (salesOrderStatus == null)
            {
                throw new ExNotFoundInDBModel(nameof(SalesOrderStatusService), nameof(GetOneByIdAsync), typeof(SalesOrderStatus), salesOrderStatusId);
            }
            return MappingToNewObj<SalesOrderStatusDto>(salesOrderStatus);
        }
    }
}
