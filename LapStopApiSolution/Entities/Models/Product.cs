using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapStopApi.Entities.Models
{
    public sealed class Product
    {
        public Guid Id { get; set; }

        public Guid ProductStatusId { get; set; }

        public string ProductCode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AvatarUrl { get; set; }

        public int OriginalPrice { get; set; }

        public int CurrentPrice { get; set; }

        public int SellingPrice { get; set; }

        public bool IsHiddenInStore { get; set; }

        public bool IsRemoved { get; set;  }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        #region NAVIGATION PROPERTIES

        public ProductStatus ProductStatus { get; set; }

        public ICollection<Product_Brand> Product_Brands { get; set; }

        public ICollection<ProductGallery>? ProductGalleries { get; set; }

        public ICollection<SalesOrderDetail>? SalesOrderDetails { get; set; }

        #endregion
    }
}
