using Microsoft.AspNetCore.Identity;

namespace Domains.IdentityModels
{
    public sealed class IdentEmployee : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
