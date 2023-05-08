using DTO.Base;

namespace DTO.Output.Data
{
    public sealed class CustomerAccountDto : BaseOutputDto
    {
        public Guid CustomerId { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool IsActivate { get; set; }
    }
}
