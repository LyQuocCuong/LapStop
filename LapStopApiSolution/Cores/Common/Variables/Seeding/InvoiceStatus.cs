namespace Common.Variables
{
    public static partial class CommonVariables
    {
        public static partial class Seeding
        {
            public static readonly Guid InvoiceStatus_Processing_Id = new Guid("00000000-0000-0000-0000-000000000201");
            public static readonly Guid InvoiceStatus_Completed_Id  = new Guid("00000000-0000-0000-0000-000000000202");
            public static readonly Guid InvoiceStatus_Blocked_Id    = new Guid("00000000-0000-0000-0000-000000000203");

            public static readonly string InvoiceStatus_Processing_Name = "Processing";
            public static readonly string InvoiceStatus_Completed_Name  = "Completed";
            public static readonly string InvoiceStatus_Blocked_Name    = "Blocked";
        }
    }
}
