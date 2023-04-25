using Domains.Base;

namespace Domains.Models
{
    public sealed class EmployeeAccount : BaseModel
    {
        public Guid EmployeeId { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool IsActivate { get; set; }

        #region NAVIGATION PROPERTIES

        public Employee? Employee { get; set; }

        #endregion
    }
}
