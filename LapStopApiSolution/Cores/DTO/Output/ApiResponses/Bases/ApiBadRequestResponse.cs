using Microsoft.AspNetCore.Http;

namespace DTO.Output.ApiResponses.Bases
{
    public abstract class ApiBadRequestResponse : ApiResponseBase
    {
        public ApiBadRequestResponse(string message)
            : base(isSuccess: false)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
