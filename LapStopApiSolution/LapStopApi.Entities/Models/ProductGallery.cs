using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapStopApi.Entities.Models
{
    public sealed class ProductGallery
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        #region NAVIGATION PROPERTIES

        public Product Product { get; set; }

        #endregion
    }
}
