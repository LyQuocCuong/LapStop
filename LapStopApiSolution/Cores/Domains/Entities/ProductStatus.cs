namespace Domains.Entities
{
    public sealed class ProductStatus : BaseEntity
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
