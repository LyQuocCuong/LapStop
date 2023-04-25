using Domains.Base;

namespace Domains.Models
{
    public sealed class ProductStatus : BaseModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool IsEnable { get; set; }

        #region NAVIGATION PROPERTIES

        public ICollection<Product>? Products { get; set; }

        #endregion
    }
}
