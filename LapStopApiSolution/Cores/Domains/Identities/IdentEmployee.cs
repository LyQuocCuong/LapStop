using Microsoft.AspNetCore.Identity;

namespace Domains.Identities
{
    public sealed class IdentEmployee : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
