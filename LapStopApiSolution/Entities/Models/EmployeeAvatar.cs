using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapStopApi.Entities.Models
{
    public class EmployeeAvatar
    {
        public Guid EmployeeId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Employee Employee { get; set; }
    }
}
