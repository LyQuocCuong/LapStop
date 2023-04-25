using Contracts.Constants;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    public class SalesOrderStatusConfig : IEntityTypeConfiguration<SalesOrderStatus>
    {
        public void Configure(EntityTypeBuilder<SalesOrderStatus> builder)
        {
            // Seeding Data
            builder.HasData(
                new SalesOrderStatus()
                {
                    Id = ConstSeedingData.SALES_ORDER_STATUS.Waiting.Id,
                    Name = ConstSeedingData.SALES_ORDER_STATUS.Waiting.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new SalesOrderStatus()
                {
                    Id = ConstSeedingData.SALES_ORDER_STATUS.Processing.Id,
                    Name = ConstSeedingData.SALES_ORDER_STATUS.Processing.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new SalesOrderStatus()
                {
                    Id = ConstSeedingData.SALES_ORDER_STATUS.Completed.Id,
                    Name = ConstSeedingData.SALES_ORDER_STATUS.Completed.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new SalesOrderStatus()
                {
                    Id = ConstSeedingData.SALES_ORDER_STATUS.Blocked.Id,
                    Name = ConstSeedingData.SALES_ORDER_STATUS.Blocked.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            );
        }
    }
}
