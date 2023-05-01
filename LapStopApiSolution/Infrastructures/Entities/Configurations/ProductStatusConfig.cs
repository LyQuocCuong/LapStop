using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Common.SeedingData;

namespace Entities.Configurations
{
    public class ProductStatusConfig : IEntityTypeConfiguration<ProductStatus>
    {
        public void Configure(EntityTypeBuilder<ProductStatus> builder)
        {
            // Seeding Data
            builder.HasData(
                CommonSeedingData.Product_Status.IN_STOCK,
                CommonSeedingData.Product_Status.OUT_OF_STOCK,
                CommonSeedingData.Product_Status.SOLD_OUT
            );
        }
    }
}
