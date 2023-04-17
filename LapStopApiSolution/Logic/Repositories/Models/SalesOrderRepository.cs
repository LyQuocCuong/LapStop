﻿using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    internal sealed class SalesOrderRepository : RepositoryBase<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(LapStopContext context) : base(context)
        {
        }
    }
}
