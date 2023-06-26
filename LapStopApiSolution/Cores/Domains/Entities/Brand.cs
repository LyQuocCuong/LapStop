namespace Domains.Entities
{
    public sealed class Brand : BaseEntity
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? AvatarUrl { get; set; }

        #region NAVIGATION PROPERTIES

        public ICollection<ProductBrand>? ProductsOfABrand { get; set; }

        #endregion
    }
}
