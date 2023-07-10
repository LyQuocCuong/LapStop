using Microsoft.AspNetCore.Http;

namespace DTO.Output.ApiResponses.Bases
{
    public abstract class ApiNotFoundResponse : ApiResponseBase
    {
        public ApiNotFoundResponse(string message)
            : base(isSuccess: false)
        {
            Message = message;
        }

        public string Message { get; }

    }
}
