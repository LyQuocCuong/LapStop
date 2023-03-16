using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapStopApi.Entities.Models
{
    public sealed class EmployeeStatus
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool IsEnable { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        #region NAVIGATION PROPERTIES

        public ICollection<Employee>? Employees { get; set; }

        #endregion
    }
}
