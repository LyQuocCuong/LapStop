using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Models
{
    public sealed class ProductBrand
    {
        public Guid ProductId { get; set; }

        public Guid BrandId { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        #region NAVIGATION PROPERTIES

        public Product? Product { get; set; }

        public Brand? Brand { get; set; }

        #endregion
    }
}
