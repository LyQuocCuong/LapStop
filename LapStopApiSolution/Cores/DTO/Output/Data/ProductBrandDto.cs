using DTO.Base;

namespace DTO.Output.Data
{
    public sealed class ProductBrandDto : BaseOutputDto
    {
        public Guid ProductId { get; set; }

        public Guid BrandId { get; set; }
    }
}
