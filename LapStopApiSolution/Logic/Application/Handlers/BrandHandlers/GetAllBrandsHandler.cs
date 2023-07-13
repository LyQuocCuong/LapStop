using Application.Handlers.Base;
using Application.Queries.BrandQueries;
using Contracts.IRepositories;
using Contracts.Utilities;
using Domains.Entities;
using DTO.Input.FromQuery.RequestPrams;
using DTO.Output.Data;
using MediatR;

namespace Application.Handlers.BrandHandlers
{
    public sealed class GetAllBrandsHandler
        : BaseRequestHandler, IRequestHandler<GetAllBrandsQuery, IEnumerable<BrandDto>>
    {
        public GetAllBrandsHandler(IDomainRepositories domainRepositories,
                                  UtilityServiceManager utilityServiceManager)
            : base(domainRepositories, utilityServiceManager)
        {
        }

        public async Task<IEnumerable<BrandDto>> Handle(GetAllBrandsQuery request, 
                                                        CancellationToken cancellationToken)
        {
            IEnumerable<Brand> brands = await EntityRepositories.Brand
                                            .GetAllAsync(request.IsTracking, new BrandRequestParam());

            var brandDtos = UtilityServices.Mapper
                                    .ExecuteMapping<IEnumerable<Brand>, IEnumerable<BrandDto>>(brands);

            return brandDtos;
        }
    }
}
