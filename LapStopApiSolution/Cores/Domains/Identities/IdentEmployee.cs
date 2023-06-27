using Microsoft.AspNetCore.Identity;

namespace Domains.Identities
{
    public sealed class IdentEmployee : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
