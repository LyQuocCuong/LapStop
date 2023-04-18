﻿using DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeRoleRepository
    {
        List<EmployeeRoleDto> GetAll();
    }
}