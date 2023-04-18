﻿using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;

namespace Services.Models
{
    internal sealed class CustomerService : ServiceBase, ICustomerService
    {
        public CustomerService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }
    }
}
