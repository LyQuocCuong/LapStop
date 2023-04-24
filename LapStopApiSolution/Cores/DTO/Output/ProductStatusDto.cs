﻿using DTO.Base;

namespace DTO.Output
{
    public sealed class ProductStatusDto : BaseOutputDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool IsEnable { get; set; }
    };
}
