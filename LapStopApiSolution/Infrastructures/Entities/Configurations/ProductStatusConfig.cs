using Contracts.Constants;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    public class ProductStatusConfig : IEntityTypeConfiguration<ProductStatus>
    {
        public void Configure(EntityTypeBuilder<ProductStatus> builder)
        {
            // Seeding Data
            builder.HasData(
                new ProductStatus()
                {
                    Id = ConstSeedingData.PRODUCT_STATUS.InStock.Id,
                    Name = ConstSeedingData.PRODUCT_STATUS.InStock.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new ProductStatus()
                {
                    Id = ConstSeedingData.PRODUCT_STATUS.OutOfStock.Id,
                    Name = ConstSeedingData.PRODUCT_STATUS.OutOfStock.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new ProductStatus()
                {
                    Id = ConstSeedingData.PRODUCT_STATUS.SoldOut.Id,
                    Name = ConstSeedingData.PRODUCT_STATUS.SoldOut.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            );
        }
    }
}
