using Contracts.IServices.Models;
using Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    internal sealed class SalesOrderDetailService : ServiceBase, ISalesOrderDetailService
    {
        public SalesOrderDetailService(LapStopContext context) : base(context)
        {
        }
    }
}
