using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Messages
{
    public static partial class CommonMessages
    {
        public static class Error
        {
            public static string NullObject(string objName)
            {
                return $"{objName} is NULL";
            }

            public static string NotFoundInDatabase(string className, string methodName, Type notFoundModelType, object notFoundValue)
            {
                return $"[ERROR] 404: {className}/{methodName}() - " +
                       $"{notFoundModelType.Name.ToUpper()} model with VALUE: " +
                       $"{notFoundValue.GetType().Name.ToUpper()} - {notFoundValue} DOESN'T exist in the database.";
            }
        }
    }
}
