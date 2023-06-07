namespace Domains.Models
{
    public sealed class EmployeeStatus : BaseModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool IsEnable { get; set; }

        #region NAVIGATION PROPERTIES

        public ICollection<Employee>? Employees { get; set; }

        #endregion
    }
}
