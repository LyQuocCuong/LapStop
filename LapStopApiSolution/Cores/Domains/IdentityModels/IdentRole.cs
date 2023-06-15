﻿using Microsoft.AspNetCore.Identity;

namespace Domains.IdentityModels
{
    public sealed class IdentRole : IdentityRole<Guid>
    {
        public override string? ConcurrencyStamp { get; set; }
    }
}
