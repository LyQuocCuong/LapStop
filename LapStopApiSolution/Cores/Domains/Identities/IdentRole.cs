using Microsoft.AspNetCore.Identity;

namespace Domains.Identities
{
    public sealed class IdentRole : IdentityRole<Guid>
    {
        public override string? ConcurrencyStamp { get; set; }
    }
}
