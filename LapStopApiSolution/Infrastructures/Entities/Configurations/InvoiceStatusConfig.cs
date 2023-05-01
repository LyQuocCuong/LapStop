using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Common.SeedingData;

namespace Entities.Configurations
{
    public class InvoiceStatusConfig : IEntityTypeConfiguration<InvoiceStatus>
    {
        public void Configure(EntityTypeBuilder<InvoiceStatus> builder)
        {
            // Seeding Data
            builder.HasData(
                CommonSeedingData.Invoice_Status.COMPLETED,
                CommonSeedingData.Invoice_Status.PROCESSING,
                CommonSeedingData.Invoice_Status.BLOCKED
            );
        }
    }
}
