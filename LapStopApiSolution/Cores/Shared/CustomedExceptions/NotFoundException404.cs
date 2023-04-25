using Contracts.Constants;
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
            : base(ConstMessages.ERROR404_NOTFOUND(className, methodName, notFoundModelType, notFoundValue))
        {
            
        }

    }
}
