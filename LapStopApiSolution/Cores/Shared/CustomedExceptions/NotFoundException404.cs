using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CustomedExceptions
{
    public sealed class NotFoundException404 : Exception
    {
        public NotFoundException404(string className, string methodName, Type notFoundModelType, object notFoundValue)
            : base($"[ERROR] 404: {className}/{methodName}() - " +
                   $"{notFoundModelType.Name.ToUpper()} with value: " +
                   $"{notFoundValue.GetType().Name.ToUpper()}-{notFoundValue} DOESN'T exist in the database.")
        {
            
        }

    }
}
