using DTO.Base;

namespace DTO.Output
{
    public sealed class ProductBrandDto : BaseOutputDto
    {
        public Guid ProductId { get; set; }

        public Guid BrandId { get; set; }
    }
}
