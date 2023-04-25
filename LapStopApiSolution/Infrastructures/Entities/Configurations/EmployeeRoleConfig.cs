using Contracts.Constants;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                    Id = ConstSeedingData.EMPLOYEE_ROLE.Admin.Id,
                    Name = ConstSeedingData.EMPLOYEE_ROLE.Admin.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new EmployeeRole()
                {
                    Id = ConstSeedingData.EMPLOYEE_ROLE.Manager.Id,
                    Name = ConstSeedingData.EMPLOYEE_ROLE.Manager.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new EmployeeRole()
                {
                    Id = ConstSeedingData.EMPLOYEE_ROLE.Staff.Id,
                    Name = ConstSeedingData.EMPLOYEE_ROLE.Staff.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            );
        }
    }
}
