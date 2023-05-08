using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Output.PagedList
{
    public sealed class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }

        public PagedList(List<T> sourceData, int totalRecords, int pageNumber, int pageSize) 
        {
            MetaData = new MetaData()
            {
                TotalRecords = totalRecords,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize),
            };

            AddRange(sourceData);
        }
    }
}
