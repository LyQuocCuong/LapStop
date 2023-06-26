namespace Domains.Entities
{
    public sealed class ProductBrand : BaseEntity
    {
        public Guid ProductId { get; set; }

        public Guid BrandId { get; set; }

        #region NAVIGATION PROPERTIES

        public Product? Product { get; set; }

        public Brand? Brand { get; set; }

        #endregion
    }
}
