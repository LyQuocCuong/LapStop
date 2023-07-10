using System.Text.Json;

namespace Common.Models.Responses
{
    public sealed class ErrorResponseModel
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
