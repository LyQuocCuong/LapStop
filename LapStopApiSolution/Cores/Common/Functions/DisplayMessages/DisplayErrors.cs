namespace Common.Functions
{
    public static partial class CommonFunctions
    {
        public static class DisplayErrors
        {
            public static string ReturnInvalidAgeRangeMessage = "Invalid Age Range";

            public static string ReturnNullObjectMessage(string objName)
            {
                return $"{objName} is NULL";
            }

            public static string ReturnNotFoundInDatabaseMessage(string className, string methodName, Type notFoundModelType, object notFoundValue)
            {
                return $"[ERROR] 404: {className}/{methodName}() - " +
                       $"{notFoundModelType.Name.ToUpper()} model with VALUE: " +
                       $"{notFoundValue.GetType().Name.ToUpper()} - {notFoundValue} DOESN'T exist in the database.";
            }
        }
    }
}
