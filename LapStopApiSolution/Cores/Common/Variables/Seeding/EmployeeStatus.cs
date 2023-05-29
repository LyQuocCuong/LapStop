namespace Common.Variables
{
    public static partial class CommonVariables
    {
        public static partial class Seeding
        {
            public static readonly Guid EmployeeStatus_On_Id      = new Guid("00000000-0000-0000-0000-000000000101");
            public static readonly Guid EmployeeStatus_Off_Id     = new Guid("00000000-0000-0000-0000-000000000102");
            public static readonly Guid EmployeeStatus_Leaving_Id = new Guid("00000000-0000-0000-0000-000000000103");

            public static readonly string EmployeeStatus_On_Name      = "On";
            public static readonly string EmployeeStatus_Off_Name     = "Off";
            public static readonly string EmployeeStatus_Leaving_Name = "Leaving";
        }
    }
}
