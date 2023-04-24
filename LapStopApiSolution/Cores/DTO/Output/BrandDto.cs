using DTO.Base;

namespace DTO.Output
{
    public sealed class BrandDto : OutputBaseDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? AvatarUrl { get; set; }
    }
}
