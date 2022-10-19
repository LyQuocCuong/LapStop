using LapStopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapStopApi.Entities.Models
{
    public sealed class Employee
    {
        public Guid Id { get; set; }

        public Guid EmployeeRoleId { get; set; }

        public Guid EmployeeStatusId { get; set; }

        public string EmployeeCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool? IsMale { get; set; }

        public DateTime DOB { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string AvatarUrl { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        #region NAVIGATION PROPERTIES

        public EmployeeRole EmployeeRole { get; set; }

        public EmployeeStatus EmployeeStatus { get; set; }

        public ICollection<EmployeeGallery> EmployeeGalleries { get; set; }

        public ICollection<ImportedInvoice> ImportedInvoices { get; set; }

        #endregion
    }
}
