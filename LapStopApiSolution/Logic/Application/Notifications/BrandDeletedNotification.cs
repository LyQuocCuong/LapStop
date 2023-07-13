using MediatR;

namespace Application.Notifications
{
    public sealed class BrandDeletedNotification
        : INotification
    {
        public Guid BrandId { get; }

        public BrandDeletedNotification(Guid brandId) 
        {
            BrandId = brandId;
        }
    }
}
