﻿namespace DTO.Input.FromBody.Creation
{
    public sealed class ProductForCreationDto
    {
        public Guid ProductStatusId { get; set; }

        public string? ProductCode { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? AvatarUrl { get; set; }

        public int OriginalPrice { get; set; }

        public int CurrentPrice { get; set; }

        public int SellingPrice { get; set; }

        public bool IsHiddenInStore { get; set; }
    }
}
