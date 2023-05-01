using Domains.Models;

namespace Shared.Common.SeedingData
{
    public static partial class CommonSeedingData
    {
        public static class Product_Status
        {
            public static readonly ProductStatus IN_STOCK = new ProductStatus()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000301"),
                Name = "In_Stock",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

            public static readonly ProductStatus OUT_OF_STOCK = new ProductStatus()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000302"),
                Name = "Out_Of_Stock",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

            public static readonly ProductStatus SOLD_OUT = new ProductStatus()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000303"),
                Name = "Sold_Out",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

        }
    }
}
