namespace Common.Variables
{
    public static partial class CommonVariables
    {
        public static partial class RefreshTokenConfig
        {
            /// <summary>
            /// Token will be expired AFTER 1 day (24 hours)
            /// </summary>
            public static DateTime ExpirationTime => DateTime.Now.AddDays(1);
        }
    }
}
