using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Id = new Guid("b7ee5e90-d212-11ed-92cb-1903471dbe5a"),
                    Name = "In Stock",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new ProductStatus()
                {
                    Id = new Guid("b7ee5e91-d212-11ed-92cb-1903471dbe5a"),
                    Name = "Out Of Stock",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new ProductStatus()
                {
                    Id = new Guid("b7ee5e92-d212-11ed-92cb-1903471dbe5a"),
                    Name = "Sold Out",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            );
        }
    }
}
