using Domains.Models;

namespace Shared.Common.SeedingData
{
    public static partial class CommonSeedingData
    {
        public static class Invoice_Status
        {
            public static readonly InvoiceStatus PROCESSING = new InvoiceStatus()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000201"),
                Name = "Processing",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

            public static readonly InvoiceStatus COMPLETED = new InvoiceStatus()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000202"),
                Name = "Completed",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

            public static readonly InvoiceStatus BLOCKED = new InvoiceStatus()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000203"),
                Name = "Blocked",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

        }
    }
}
