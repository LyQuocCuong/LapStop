using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configurations
{
    public class EmployeeRoleConfig : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            // Seeding Data
            builder.HasData(
                new EmployeeRole()
                {
                    Id = new Guid("e6d15a40-d1e1-11ed-92cb-1903471dbe5a"),
                    Name = "Admin",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new EmployeeRole()
                {
                    Id = new Guid("e6d15a41-d1e1-11ed-92cb-1903471dbe5a"),
                    Name = "Manager",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new EmployeeRole()
                {
                    Id = new Guid("e6d15a42-d1e1-11ed-92cb-1903471dbe5a"),
                    Name = "Staff",
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            );
        }
    }
}
