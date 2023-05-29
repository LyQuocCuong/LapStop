namespace Common.Variables
{
    public static partial class CommonVariables
    {
        public static partial class Seeding
        {
            public static readonly Guid SalesOrderStatus_Waiting_Id     = new Guid("00000000-0000-0000-0000-000000000401");
            public static readonly Guid SalesOrderStatus_Processing_Id  = new Guid("00000000-0000-0000-0000-000000000402");
            public static readonly Guid SalesOrderStatus_Completed_Id   = new Guid("00000000-0000-0000-0000-000000000403");
            public static readonly Guid SalesOrderStatus_Blocked_Id     = new Guid("00000000-0000-0000-0000-000000000404");

            public static readonly string SalesOrderStatus_Waiting_Name     = "Waiting";
            public static readonly string SalesOrderStatus_Processing_Name  = "Processing";
            public static readonly string SalesOrderStatus_Completed_Name   = "Completed";
            public static readonly string SalesOrderStatus_Blocked_Name     = "Blocked";
        }
    }
}
