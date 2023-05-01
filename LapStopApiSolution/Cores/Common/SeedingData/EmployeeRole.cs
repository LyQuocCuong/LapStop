using Common.SeedingData.Objects;

namespace Common.Seeding
{
    public static partial class CommonSeedingData
    {
        public static class EmployeeRole
        {
            #region ADMIN

            private static readonly EmployeeRoleObj _admin = new EmployeeRoleObj()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                Name = "Admin",
            };
            public static class ADMIN
            {
                public static Guid Id
                {
                    get
                    {
                        return _admin.Id;
                    }
                }
                public static string Name
                {
                    get
                    {
                        return _admin.Name;
                    }
                }
            }

            #endregion

            #region MANAGER

            private static readonly EmployeeRoleObj _manager = new EmployeeRoleObj()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                Name = "Manager",
            };
            public static class MANAGER
            {
                public static Guid Id
                {
                    get
                    {
                        return _manager.Id;
                    }
                }
                public static string Name
                {
                    get
                    {
                        return _manager.Name;
                    }
                }
            }

            #endregion

            #region STAFF

            private static readonly EmployeeRoleObj _staff = new EmployeeRoleObj()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                Name = "Staff",
            };
            public static class STAFF
            {
                public static Guid Id
                {
                    get
                    {
                        return _staff.Id;
                    }
                }
                public static string Name
                {
                    get
                    {
                        return _staff.Name;
                    }
                }
            }

            #endregion

        }
    }
}
