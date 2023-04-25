using Domains.Base;

namespace Domains.Models
{
    public sealed class CustomerAccount : BaseModel
    {
        public Guid CustomerId { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool IsActivate { get; set; }

        #region NAVIGATION PROPERTIES

        public Customer? Customer { get; set; }

        #endregion

    }
}
