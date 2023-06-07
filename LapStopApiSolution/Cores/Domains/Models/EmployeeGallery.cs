namespace Domains.Models
{
    public sealed class EmployeeGallery : BaseModel
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public string? Title { get; set; }

        public string? Url { get; set; }


        #region NAVIGATION PROPERTIES

        public Employee? Employee { get; set; }

        #endregion
    }
}
