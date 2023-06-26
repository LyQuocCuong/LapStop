using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreService.Configurations.Entities
{
    internal sealed class EmployeeStatusConfig : IEntityTypeConfiguration<EmployeeStatus>
    {
        public void Configure(EntityTypeBuilder<EmployeeStatus> builder)
        {
            // Seeding Data
            builder.HasData(
                new EmployeeStatus()
                {
                    Id = CommonVariables.Seeding.EmployeeStatus_Leaving_Id,
                    Name = CommonVariables.Seeding.EmployeeStatus_Leaving_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                },
                new EmployeeStatus()
                {
                    Id = CommonVariables.Seeding.EmployeeStatus_Off_Id,
                    Name = CommonVariables.Seeding.EmployeeStatus_Off_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                },
                new EmployeeStatus()
                {
                    Id = CommonVariables.Seeding.EmployeeStatus_On_Id,
                    Name = CommonVariables.Seeding.EmployeeStatus_On_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                }
            );
        }
    }
}
