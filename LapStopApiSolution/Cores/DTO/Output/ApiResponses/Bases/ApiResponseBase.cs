namespace DTO.Output.ApiResponses.Bases
{
    public abstract class ApiResponseBase
    {
        protected ApiResponseBase(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        // IsSuccess just help to CAST model
        // CASTING to ApiOkReponse or ApiNotFoundResponse
        public bool IsSuccess { get; }
    }
}
