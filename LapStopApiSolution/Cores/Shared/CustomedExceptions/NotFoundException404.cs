using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CustomedExceptions
{
    public sealed class NotFoundException404 : Exception
    {
        public NotFoundException404(Type modelType, string methodName, object notFoundValue) 
            : base($"[ERROR] 404: {modelType.Name.ToUpper()} model in {methodName}() METHOD with value : {notFoundValue} doesn't exist in the database.") 
        {
            
        }

    }
}
