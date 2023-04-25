namespace Contracts.Constants
{
    public static class ConstSeedingData
    {
        public static class EMPLOYEE_ROLE
        {
            public static class Admin
            {
                public static Guid Id = new Guid("e6d15a40-d1e1-11ed-92cb-1903471dbe5a");
                public static string Name = "Admin";
            }

            public static class Manager
            {
                public static Guid Id = new Guid("e6d15a41-d1e1-11ed-92cb-1903471dbe5a");
                public static string Name = "Manager";
            }

            public static class Staff
            {
                public static Guid Id = new Guid("e6d15a42-d1e1-11ed-92cb-1903471dbe5a");
                public static string Name = "Staff";
            }
        }

        public static class EMPLOYEE_STATUS
        {
            public static class On
            {
                public static Guid Id = new Guid("b3d637e0-d20a-11ed-92cb-1903471dbe5a");
                public static string Name = "On";
            }

            public static class Off
            {
                public static Guid Id = new Guid("b3d637e1-d20a-11ed-92cb-1903471dbe5a");
                public static string Name = "Off";
            }

            public static class Leaving
            {
                public static Guid Id = new Guid("b3d637e2-d20a-11ed-92cb-1903471dbe5a");
                public static string Name = "Leaving";
            }
        }

        public static class INVOICE_STATUS
        {
            public static class Processing
            {
                public static Guid Id = new Guid("7187a500-d213-11ed-92cb-1903471dbe5a");
                public static string Name = "Processing";
            }

            public static class Completed
            {
                public static Guid Id = new Guid("7187a501-d213-11ed-92cb-1903471dbe5a");
                public static string Name = "Completed";
            }

            public static class Blocked
            {
                public static Guid Id = new Guid("7187a502-d213-11ed-92cb-1903471dbe5a");
                public static string Name = "Blocked";
            }
        }

        public static class PRODUCT_STATUS
        {
            public static class InStock
            {
                public static Guid Id = new Guid("b7ee5e90-d212-11ed-92cb-1903471dbe5a");
                public static string Name = "In Stock";
            }

            public static class OutOfStock
            {
                public static Guid Id = new Guid("b7ee5e91-d212-11ed-92cb-1903471dbe5a");
                public static string Name = "Out Of Stock";
            }

            public static class SoldOut
            {
                public static Guid Id = new Guid("b7ee5e92-d212-11ed-92cb-1903471dbe5a");
                public static string Name = "Sold Out";
            }
        }

        public static class SALES_ORDER_STATUS
        {
            public static class Waiting
            {
                public static Guid Id = new Guid("feb2d310-d212-11ed-92cb-1903471dbe5a");
                public static string Name = "Waiting";
            }

            public static class Processing
            {
                public static Guid Id = new Guid("feb2d311-d212-11ed-92cb-1903471dbe5a");
                public static string Name = "Processing";
            }

            public static class Completed
            {
                public static Guid Id = new Guid("feb2d312-d212-11ed-92cb-1903471dbe5a");
                public static string Name = "Completed";
            }

            public static class Blocked
            {
                public static Guid Id = new Guid("feb2d313-d212-11ed-92cb-1903471dbe5a");
                public static string Name = "Blocked";
            }
        }

    }
    
}
