using DTO.Output.Data;
using MediatR;

namespace Application.Queries.BrandQueries
{
    public sealed class GetBrandByIdQuery
        : IRequest<BrandDto>
    {
        public bool IsTracking { get; }
        public Guid BrandId { get; }

        public GetBrandByIdQuery(bool isTracking, Guid brandId) 
        {
            IsTracking = isTracking;
            BrandId = brandId;
        }
    }
}
