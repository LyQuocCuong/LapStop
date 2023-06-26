namespace Domains.Entities
{
    public sealed class Employee : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid EmployeeRoleId { get; set; }

        public Guid EmployeeStatusId { get; set; }

        public string? EmployeeCode { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool? IsMale { get; set; }

        public DateTime DOB { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? AvatarUrl { get; set; }

        #region NAVIGATION PROPERTIES

        public EmployeeAccount? EmployeeAccount { get; set; }

        public EmployeeRole? EmployeeRole { get; set; }

        public EmployeeStatus? EmployeeStatus { get; set; }

        public ICollection<EmployeeGallery>? EmployeeGalleries { get; set; }

        public ICollection<ImportedInvoice>? ImportedInvoices { get; set; }

        public ICollection<ExportedInvoice>? ExportedInvoices { get; set; }

        #endregion
    }
}
