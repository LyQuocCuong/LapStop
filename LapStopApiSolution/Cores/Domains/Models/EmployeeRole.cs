namespace Domains.Models
{
    public sealed class EmployeeRole : BaseModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool IsEnable { get; set; }

        #region NAVIGATION PROPERTIES

        public ICollection<Employee>? Employees { get; set; }

        #endregion
    }
}
