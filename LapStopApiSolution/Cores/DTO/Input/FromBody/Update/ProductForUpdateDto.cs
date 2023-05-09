using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Input.FromBody.Update
{
    public sealed class ProductForUpdateDto
    {
        public Guid ProductStatusId { get; set; }

        public string? ProductCode { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? AvatarUrl { get; set; }

        public int OriginalPrice { get; set; }

        public int CurrentPrice { get; set; }

        public int SellingPrice { get; set; }

        public bool IsHiddenInStore { get; set; }
    }
}
