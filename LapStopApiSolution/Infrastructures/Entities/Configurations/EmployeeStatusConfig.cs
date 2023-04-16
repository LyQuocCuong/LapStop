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
    public class EmployeeStatusConfig : IEntityTypeConfiguration<EmployeeStatus>
    {
        public void Configure(EntityTypeBuilder<EmployeeStatus> builder)
        {
            // Seeding Data
            builder.HasData(
                new EmployeeStatus()
                {
                    Id = new Guid("b3d637e0-d20a-11ed-92cb-1903471dbe5a"),
                    Name = "On",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new EmployeeStatus()
                {
                    Id = new Guid("b3d637e1-d20a-11ed-92cb-1903471dbe5a"),
                    Name = "Off",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new EmployeeStatus()
                {
                    Id = new Guid("b3d637e2-d20a-11ed-92cb-1903471dbe5a"),
                    Name = "Leaving",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            );
        }
    }
}
