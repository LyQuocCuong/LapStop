using DTO.Output.Data;
using MediatR;

namespace Application.Queries.BrandQueries
{
    public sealed class GetAllBrandsQuery
        : IRequest<IEnumerable<BrandDto>>
    {
        public bool IsTracking { get; }

        public GetAllBrandsQuery(bool isTracking) 
        { 
            IsTracking = isTracking;
        }
    }
}
