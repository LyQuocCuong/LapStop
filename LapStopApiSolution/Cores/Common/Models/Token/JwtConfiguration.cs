namespace Common.Models.Token
{
    public sealed class JwtConfiguration
    {
        public string Section { get; set; } = "JwtSettings"; 

        public string? ValidIssuer { get; set; }
        public string? ValidAudience { get; set; }
        public string? ExpirationMinutes { get; set; }
    }
}
