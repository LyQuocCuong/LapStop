using AutoMapper;
using Domains.Models;
using DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperLib
{
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ProductStatus, ProductStatusDto>();
                //.ForCtorParam("Description", 
                //           value => value.MapFrom(p => string.Join(p.Description, "...")));
        }
    }
}
