using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class EmployeeGallery
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public string? Title { get; set; }

        public string? Url { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }


        #region NAVIGATION PROPERTIES

        public Employee? Employee { get; set; }

        #endregion
    }
}
