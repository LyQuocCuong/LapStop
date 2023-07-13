using Application.Commands.BrandCommands;
using Application.Handlers.Base;
using Contracts.IRepositories;
using Contracts.Utilities;
using Domains.Entities;
using DTO.Input.FromBody.Update;
using MediatR;

namespace Application.Handlers.BrandHandlers
{
    public sealed class UpdateBrandHandler
        : BaseRequestHandler, IRequestHandler<UpdateBrandCommand>
    {
        public UpdateBrandHandler(IDomainRepositories domainRepositories, 
                                  UtilityServiceManager utilityServiceManager)
            : base(domainRepositories, utilityServiceManager)
        {
        }

        public async Task Handle(UpdateBrandCommand request, 
                                 CancellationToken cancellationToken)
        {
            Brand? brand = await EntityRepositories.Brand
                            .GetOneByIdAsync(isTrackChanges: true, request.BrandId);
            if (brand != null)
            {
                UtilityServices.Mapper
                    .ExecuteMapping<BrandForUpdateDto, Brand>(request.UpdateDto, brand);
                await SaveChanges();
            }
            await Task.CompletedTask;
        }
    }
}
