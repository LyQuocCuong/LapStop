namespace Domains.Entities
{
    public sealed class EmployeeAccount : BaseEntity
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
