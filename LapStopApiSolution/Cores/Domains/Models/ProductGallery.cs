using Domains.Base;

namespace Domains.Models
{
    public sealed class ProductGallery : BaseModel
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string? Title { get; set; }

        public string? Url { get; set; }

        #region NAVIGATION PROPERTIES

        public Product? Product { get; set; }

        #endregion
    }
}
