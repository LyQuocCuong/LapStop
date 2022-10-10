using LapStopApi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapStopApi.Models
{
    public class EmployeeRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActivate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
