using Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal abstract class ServiceBase
    {
        protected LapStopContext _context;
        internal ServiceBase(LapStopContext context)
        {
            _context = context;
        }
    }
}
