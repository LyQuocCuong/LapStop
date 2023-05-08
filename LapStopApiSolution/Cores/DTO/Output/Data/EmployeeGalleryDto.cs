using DTO.Base;

namespace DTO.Output.Data
{
    public sealed class EmployeeGalleryDto : BaseOutputDto
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public string? Title { get; set; }

        public string? Url { get; set; }
    }
}
