using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Common.SeedingData;

namespace Entities.Configurations
{
    public class EmployeeRoleConfig : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            // Seeding Data
            builder.HasData(
                CommonSeedingData.Employee_Role.ADMIN,
                CommonSeedingData.Employee_Role.MANAGER,
                CommonSeedingData.Employee_Role.STAFF
            );
        }
    }
}
