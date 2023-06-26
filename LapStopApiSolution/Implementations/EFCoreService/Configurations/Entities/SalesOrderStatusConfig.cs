using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreService.Configurations.Entities
{
    internal sealed class SalesOrderStatusConfig : IEntityTypeConfiguration<SalesOrderStatus>
    {
        public void Configure(EntityTypeBuilder<SalesOrderStatus> builder)
        {
            // Seeding Data
            builder.HasData(
                new SalesOrderStatus()
                {
                    Id = CommonVariables.Seeding.SalesOrderStatus_Blocked_Id,
                    Name = CommonVariables.Seeding.SalesOrderStatus_Blocked_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                },
                new SalesOrderStatus()
                {
                    Id = CommonVariables.Seeding.SalesOrderStatus_Completed_Id,
                    Name = CommonVariables.Seeding.SalesOrderStatus_Completed_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                },
                new SalesOrderStatus()
                {
                    Id = CommonVariables.Seeding.SalesOrderStatus_Processing_Id,
                    Name = CommonVariables.Seeding.SalesOrderStatus_Processing_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                },
                new SalesOrderStatus()
                {
                    Id = CommonVariables.Seeding.SalesOrderStatus_Waiting_Id,
                    Name = CommonVariables.Seeding.SalesOrderStatus_Waiting_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                }
            );
        }
    }
}
