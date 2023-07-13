using Application.Commands.BrandCommands;
using Application.Handlers.Base;
using Application.Notifications;
using Contracts.IRepositories;
using Contracts.Utilities;
using Domains.Entities;
using MediatR;

namespace Application.Handlers.BrandHandlers
{
    public sealed class DeleteBrandHandler
        : BaseRequestHandler, INotificationHandler<BrandDeletedNotification>
    {
        public DeleteBrandHandler(IDomainRepositories domainRepositories, 
                                  UtilityServiceManager utilityServices) 
            : base(domainRepositories, utilityServices)
        {
        }

        public async Task Handle(BrandDeletedNotification notification, 
                                 CancellationToken cancellationToken)
        {
            Brand? brand = await EntityRepositories.Brand
                .GetOneByIdAsync(isTrackChanges: true, notification.BrandId);
            if (brand != null)
            {
                EntityRepositories.Brand.Delete(brand);
                await SaveChanges();
            }
        }
    }
}
