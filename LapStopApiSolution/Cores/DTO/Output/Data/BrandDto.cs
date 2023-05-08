using DTO.Base;

namespace DTO.Output.Data
{
    public sealed class BrandDto : BaseOutputDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? AvatarUrl { get; set; }
    }
}
