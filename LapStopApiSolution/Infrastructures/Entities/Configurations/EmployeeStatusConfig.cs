using Contracts.Constants;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                    Id = ConstSeedingData.EMPLOYEE_STATUS.On.Id,
                    Name = ConstSeedingData.EMPLOYEE_STATUS.On.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new EmployeeStatus()
                {
                    Id = ConstSeedingData.EMPLOYEE_STATUS.Off.Id,
                    Name = ConstSeedingData.EMPLOYEE_STATUS.Off.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new EmployeeStatus()
                {
                    Id = ConstSeedingData.EMPLOYEE_STATUS.Leaving.Id,
                    Name = ConstSeedingData.EMPLOYEE_STATUS.Leaving.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            );
        }
    }
}
