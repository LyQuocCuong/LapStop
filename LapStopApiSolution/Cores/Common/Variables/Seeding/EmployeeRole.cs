namespace Common.Variables
{
    public static partial class CommonVariables
    {
        public static partial class Seeding
        {
            public static readonly Guid EmployeeRole_Admin_Id    = new Guid("00000000-0000-0000-0000-000000000001");
            public static readonly Guid EmployeeRole_Manager_Id  = new Guid("00000000-0000-0000-0000-000000000002");
            public static readonly Guid EmployeeRole_Staff_Id    = new Guid("00000000-0000-0000-0000-000000000003");

            public static readonly string EmployeeRole_Admin_Name    = "Admin";
            public static readonly string EmployeeRole_Manager_Name  = "Manager";
            public static readonly string EmployeeRole_Staff_Name    = "Staff";
        }
    }
}
