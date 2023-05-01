using Domains.Models;

namespace Shared.Common.SeedingData
{
    public static partial class CommonSeedingData
    {
        public static class Employee_Role
        {
            public static readonly EmployeeRole ADMIN = new EmployeeRole()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                Name = "Admin",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

            public static readonly EmployeeRole MANAGER = new EmployeeRole()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                Name = "Manager",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

            public static readonly EmployeeRole STAFF = new EmployeeRole()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                Name = "Staff",
                IsRemoved = false,
                CreatedDate = DefaultCreatedDate,
                UpdatedDate = DefaultUpdateDate,
            };

        }
    }
}
