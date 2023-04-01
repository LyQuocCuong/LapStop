using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class EmployeeAccount
    {
        public Guid EmployeeId { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool IsActivate { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        #region NAVIGATION PROPERTIES

        public Employee? Employee { get; set; }

        #endregion
    }
}
