using DTO.Bases;

namespace DTO.Input.FromQuery.RequestPrams
{
    public sealed class BrandRequestParam : BasePOSRequestParam
    {
        public string? ShapingProps { get; set; }
    }
}
