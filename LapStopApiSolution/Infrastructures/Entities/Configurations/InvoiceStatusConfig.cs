using Common.Variables;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    internal sealed class InvoiceStatusConfig : IEntityTypeConfiguration<InvoiceStatus>
    {
        public void Configure(EntityTypeBuilder<InvoiceStatus> builder)
        {
            // Seeding Data
            builder.HasData(
                new InvoiceStatus()
                {
                    Id = CommonVariables.Seeding.InvoiceStatus_Blocked_Id,
                    Name = CommonVariables.Seeding.InvoiceStatus_Blocked_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                },
                new InvoiceStatus()
                {
                    Id = CommonVariables.Seeding.InvoiceStatus_Completed_Id,
                    Name = CommonVariables.Seeding.InvoiceStatus_Completed_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                },
                new InvoiceStatus()
                {
                    Id = CommonVariables.Seeding.InvoiceStatus_Processing_Id,
                    Name = CommonVariables.Seeding.InvoiceStatus_Processing_Name,
                    IsRemoved = CommonVariables.Seeding.DefaultIsRemoved,
                    CreatedDate = CommonVariables.Seeding.DefaultCreatedDate,
                    UpdatedDate = CommonVariables.Seeding.DefaultUpdateDate,
                }
            );
        }
    }
}
