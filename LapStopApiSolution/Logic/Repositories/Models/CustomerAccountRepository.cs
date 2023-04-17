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
    public sealed class CustomerAccountRepository : RepositoryBase<CustomerAccount>, ICustomerAccountRepository
    {
        public CustomerAccountRepository(LapStopContext context) : base(context)
        {
        }
    }
}
