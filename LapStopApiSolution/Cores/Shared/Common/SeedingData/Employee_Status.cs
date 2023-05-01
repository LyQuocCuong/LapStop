using Domains.Models;

namespace Shared.Common.SeedingData
{
    public static partial class CommonSeedingData
    {
        public static class Employee_Status
        {
            public static readonly EmployeeStatus ON = new EmployeeStatus()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000101"),
                Name = "On",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

            public static readonly EmployeeStatus OFF = new EmployeeStatus()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000102"),
                Name = "Off",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

            public static readonly EmployeeStatus LEAVING = new EmployeeStatus()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000103"),
                Name = "Leaving",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };
        }
    }
}
