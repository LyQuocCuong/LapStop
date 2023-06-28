namespace Services.Entities
{
    internal sealed class SalesOrderStatusService : AbstractService, ISalesOrderStatusService
    {
        public SalesOrderStatusService(ServiceParams serviceParams) : base(serviceParams)
        {
        }

        public async Task<IEnumerable<SalesOrderStatusDto>> GetAllAsync()
        {
            IEnumerable<SalesOrderStatus> salesOrderStatuses = await EntityRepositories.SalesOrderStatus.GetAllAsync(isTrackChanges: false);
            return UtilityServices.Mapper.ExecuteMapping<IEnumerable<SalesOrderStatus>, IEnumerable<SalesOrderStatusDto>>(salesOrderStatuses);
        }

        public async Task<SalesOrderStatusDto?> GetOneByIdAsync(Guid salesOrderStatusId)
        {
            SalesOrderStatus? salesOrderStatus = await EntityRepositories.SalesOrderStatus.GetOneByIdAsync(isTrackChanges: false, salesOrderStatusId);
            if (salesOrderStatus == null)
            {
                throw new ExNotFoundInDBModel(nameof(SalesOrderStatusService), nameof(GetOneByIdAsync), typeof(SalesOrderStatus), salesOrderStatusId);
            }
            return UtilityServices.Mapper.ExecuteMapping<SalesOrderStatus, SalesOrderStatusDto>(salesOrderStatus);
        }
    }
}
