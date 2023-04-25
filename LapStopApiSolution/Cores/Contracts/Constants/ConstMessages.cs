using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Constants
{
    public static class ConstMessages
    {
        public static string OBJECT_IS_NULL(string objName)
        {
            return $"{objName} is NULL";
        }

        public static string ERROR404_NOTFOUND(string className, string methodName, Type notFoundModelType, object notFoundValue)
        {
            return $"[ERROR] 404: {className}/{methodName}() - " +
                   $"{notFoundModelType.Name.ToUpper()} model with VALUE: " +
                   $"{notFoundValue.GetType().Name.ToUpper()} - {notFoundValue} DOESN'T exist in the database.";
        }

    }
}
