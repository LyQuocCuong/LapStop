namespace Domains.Entities
{
    public sealed class EmployeeRole : BaseEntity
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool IsEnable { get; set; }

        #region NAVIGATION PROPERTIES

        public ICollection<Employee>? Employees { get; set; }

        #endregion
    }
}
