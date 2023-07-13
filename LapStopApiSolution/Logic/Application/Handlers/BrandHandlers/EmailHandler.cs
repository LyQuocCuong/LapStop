using Application.Notifications;
using Contracts.Utilities.Logger;
using MediatR;

namespace Application.Handlers.BrandHandlers
{
    internal sealed class EmailHandler
        : INotificationHandler<BrandDeletedNotification>
    {
        private ILogService _logService;
        public EmailHandler(ILogService logService) 
        {
            _logService = logService;
        }

        public async Task Handle(BrandDeletedNotification notification, 
                                 CancellationToken cancellationToken)
        {
            _logService.LogInfo("Execute EmailHandler");
            await Task.CompletedTask;
        }
    }
}
