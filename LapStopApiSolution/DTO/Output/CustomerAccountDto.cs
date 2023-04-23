using DTO.Base;

namespace DTO.Output
{
    public sealed class CustomerAccountDto : OutputBaseDto
    {
        public Guid CustomerId { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool IsActivate { get; set; }
    }
}
