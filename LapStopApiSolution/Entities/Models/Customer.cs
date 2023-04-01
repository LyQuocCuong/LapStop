using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class Customer
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        #region NAVIGATION PROPERTIES

        public CustomerAccount? CustomerAccount { get; set; }

        public Cart? Cart { get; set; }

        public ICollection<SalesOrder>? SalesOrders { get; set; }

        #endregion
    }
}
