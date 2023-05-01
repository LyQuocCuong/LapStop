using Domains.Models;

namespace Shared.Common.SeedingData
{
    public static partial class CommonSeedingData
    {
        public static class SalesOrder_Status
        {
            public static readonly SalesOrderStatus WAITING = new SalesOrderStatus()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000401"),
                Name = "Waiting",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

            public static readonly SalesOrderStatus PROCESSING = new SalesOrderStatus()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000402"),
                Name = "Processing",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

            public static readonly SalesOrderStatus COMPLETED = new SalesOrderStatus()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000403"),
                Name = "Completed",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

            public static readonly SalesOrderStatus BLOCKED = new SalesOrderStatus()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000404"),
                Name = "Blocked",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

        }
    }
}
