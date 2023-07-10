using DTO.Output.ApiResponses.Bases;

namespace RestfulApiHandler.Extensions
{
    public static class ApiBaseResponseExtensions
    {
        public static TResultType GetResult<TResultType>(this ApiResponseBase apiResponse)
        {
            return ((ApiOkResponse<TResultType>)apiResponse).Data;
        }
    }
}
