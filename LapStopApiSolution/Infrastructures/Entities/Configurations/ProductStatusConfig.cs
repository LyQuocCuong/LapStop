using Common.Variables;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    internal sealed class ProductStatusConfig : IEntityTypeConfiguration<ProductStatus>
    {
        public void Configure(EntityTypeBuilder<ProductStatus> builder)
        {
            // Seeding Data
            builder.HasData(
                new ProductStatus()
                {
                    Id = CommonVariables.Seeding.ProductStatus_InStock_Id,
                    Name = CommonVariables.Seeding.ProductStatus_InStock_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                },
                new ProductStatus()
                {
                    Id = CommonVariables.Seeding.ProductStatus_OutOfStock_Id,
                    Name = CommonVariables.Seeding.ProductStatus_OutOfStock_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                },
                new ProductStatus()
                {
                    Id = CommonVariables.Seeding.ProductStatus_SoldOut_Id,
                    Name = CommonVariables.Seeding.ProductStatus_SoldOut_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                }
            );
        }
    }
}
