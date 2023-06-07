namespace Domains.Models
{
    public sealed class ProductBrand : BaseModel
    {
        public Guid ProductId { get; set; }

        public Guid BrandId { get; set; }

        #region NAVIGATION PROPERTIES

        public Product? Product { get; set; }

        public Brand? Brand { get; set; }

        #endregion
    }
}
