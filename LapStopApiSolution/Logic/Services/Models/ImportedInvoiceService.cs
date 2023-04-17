using Contracts.IServices.Models;
using Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    internal sealed class ImportedInvoiceService : ServiceBase, IImportedInvoiceService
    {
        public ImportedInvoiceService(LapStopContext context) : base(context)
        {
        }
    }
}
