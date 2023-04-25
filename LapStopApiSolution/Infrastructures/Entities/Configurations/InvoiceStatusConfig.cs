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
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new InvoiceStatus()
                {
                    Id = ConstSeedingData.INVOICE_STATUS.Completed.Id,
                    Name = ConstSeedingData.INVOICE_STATUS.Completed.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new InvoiceStatus()
                {
                    Id = ConstSeedingData.INVOICE_STATUS.Blocked.Id,
                    Name = ConstSeedingData.INVOICE_STATUS.Blocked.Name,
                    IsEnable = true,
                    IsRemoved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            );
        }
    }
}
