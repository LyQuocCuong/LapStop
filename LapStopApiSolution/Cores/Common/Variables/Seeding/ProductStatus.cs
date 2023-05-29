namespace Common.Variables
{
    public static partial class CommonVariables
    {
        public static partial class Seeding
        {
            public static readonly Guid ProductStatus_InStock_Id     = new Guid("00000000-0000-0000-0000-000000000301");
            public static readonly Guid ProductStatus_OutOfStock_Id  = new Guid("00000000-0000-0000-0000-000000000302");
            public static readonly Guid ProductStatus_SoldOut_Id     = new Guid("00000000-0000-0000-0000-000000000303");

            public static readonly string ProductStatus_InStock_Name     = "In_Stock";
            public static readonly string ProductStatus_OutOfStock_Name  = "Out_Of_Stock";
            public static readonly string ProductStatus_SoldOut_Name     = "Sold_Out";
        }
    }
}
