using Contracts.Constants;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    public class InvoiceStatusConfig : IEntityTypeConfiguration<InvoiceStatus>
    {
        public void Configure(EntityTypeBuilder<InvoiceStatus> builder)
        {
            // Seeding Data
            builder.HasData(
                new InvoiceStatus()
                {
                    Id = ConstSeedingData.INVOICE_STATUS.Processing.Id,
                    Name = ConstSeedingData.INVOICE_STATUS.Processing.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local),
                    UpdatedDate = new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local),
                },
                new InvoiceStatus()
                {
                    Id = ConstSeedingData.INVOICE_STATUS.Completed.Id,
                    Name = ConstSeedingData.INVOICE_STATUS.Completed.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local),
                    UpdatedDate = new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local),
                },
                new InvoiceStatus()
                {
                    Id = ConstSeedingData.INVOICE_STATUS.Blocked.Id,
                    Name = ConstSeedingData.INVOICE_STATUS.Blocked.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local),
                    UpdatedDate = new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local),
                }
            );
        }
    }
}
