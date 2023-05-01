using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Common.SeedingData;

namespace Entities.Configurations
{
    public class EmployeeStatusConfig : IEntityTypeConfiguration<EmployeeStatus>
    {
        public void Configure(EntityTypeBuilder<EmployeeStatus> builder)
        {
            // Seeding Data
            builder.HasData(
                CommonSeedingData.Employee_Status.ON,
                CommonSeedingData.Employee_Status.OFF,
                CommonSeedingData.Employee_Status.LEAVING
            );
        }
    }
}
