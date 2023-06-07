using System.ComponentModel.DataAnnotations;

namespace DTO.Input.FromBody.Update
{
    public class ProductForBulkUpdateDto
    {
        [Required(ErrorMessage = "a required field")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "a required field")]
        public Guid ProductStatusId { get; set; }

        [Required(ErrorMessage = "a required field")]
        [MaxLength(10, ErrorMessage = "Maximum length is 10 characters.")]
        public string? ProductCode { get; set; }

        [Required(ErrorMessage = "a required field")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? AvatarUrl { get; set; }

        [Range(1000, int.MaxValue, ErrorMessage = "a required field")]
        public int OriginalPrice { get; set; }

        [Range(1000, int.MaxValue, ErrorMessage = "a required field")]
        public int CurrentPrice { get; set; }

        [Range(1000, int.MaxValue, ErrorMessage = "a required field")]
        public int SellingPrice { get; set; }

        public bool IsHiddenInStore { get; set; }
    }
}
