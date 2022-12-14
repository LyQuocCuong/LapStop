using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapStopApi.Entities.Models
{
    public sealed class Cart
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public int Total { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        #region NAVIGATION PROPERTIES

        public ICollection<CartItem>? CartItems { get; set; }

        #endregion

    }
}
