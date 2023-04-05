using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Id = new Guid("feb2d310-d212-11ed-92cb-1903471dbe5a"),
                    Name = "Waiting",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new SalesOrderStatus()
                {
                    Id = new Guid("feb2d311-d212-11ed-92cb-1903471dbe5a"),
                    Name = "Processing",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new SalesOrderStatus()
                {
                    Id = new Guid("feb2d312-d212-11ed-92cb-1903471dbe5a"),
                    Name = "Completed",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new SalesOrderStatus()
                {
                    Id = new Guid("feb2d313-d212-11ed-92cb-1903471dbe5a"),
                    Name = "Blocked",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            );
        }
    }
}
