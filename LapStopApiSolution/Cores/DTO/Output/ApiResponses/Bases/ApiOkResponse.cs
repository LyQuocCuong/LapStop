using Microsoft.AspNetCore.Http;

namespace DTO.Output.ApiResponses.Bases
{
    public sealed class ApiOkResponse<TReturnedDataType> : ApiResponseBase
    {
        public ApiOkResponse(TReturnedDataType data)
            : base(isSuccess: true)
        {
            Data = data;
        }

        public TReturnedDataType Data { get; }
    }
}
