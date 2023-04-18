﻿using DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices.Models
{
    public interface IProductStatusService
    {
        IEnumerable<ProductStatusDto> GetAll();
    }
}
