using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Common.SeedingData;

namespace Entities.Configurations
{
    public class SalesOrderStatusConfig : IEntityTypeConfiguration<SalesOrderStatus>
    {
        public void Configure(EntityTypeBuilder<SalesOrderStatus> builder)
        {
            // Seeding Data
            builder.HasData(
                CommonSeedingData.SalesOrder_Status.WAITING,
                CommonSeedingData.SalesOrder_Status.BLOCKED,
                CommonSeedingData.SalesOrder_Status.PROCESSING,
                CommonSeedingData.SalesOrder_Status.COMPLETED
            );
        }
    }
}
