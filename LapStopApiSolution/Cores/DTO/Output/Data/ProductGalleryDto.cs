using DTO.Bases;

namespace DTO.Output.Data
{
    public sealed class ProductGalleryDto : BaseOutputDto
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string? Title { get; set; }

        public string? Url { get; set; }
    }
}
