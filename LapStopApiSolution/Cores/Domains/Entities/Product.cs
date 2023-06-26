namespace Domains.Entities
{
    public sealed class Product : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid ProductStatusId { get; set; }

        public string? ProductCode { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? AvatarUrl { get; set; }

        public int OriginalPrice { get; set; }

        public int CurrentPrice { get; set; }

        public int SellingPrice { get; set; }

        public bool IsHiddenInStore { get; set; }

        #region NAVIGATION PROPERTIES

        public ProductStatus? ProductStatus { get; set; }

        public ICollection<ProductBrand>? BrandsOfAProduct { get; set; }

        public ICollection<ProductGallery>? ProductGalleries { get; set; }

        public ICollection<CartItem>? CartItems { get; set; }

        public ICollection<SalesOrderDetail>? SalesOrderDetails { get; set; }

        public ICollection<ImportedInvoiceDetail>? ImportedInvoiceDetails { get; set; }

        public ICollection<ExportedInvoiceDetail>? ExportedInvoiceDetails { get; set; }

        #endregion
    }
}
