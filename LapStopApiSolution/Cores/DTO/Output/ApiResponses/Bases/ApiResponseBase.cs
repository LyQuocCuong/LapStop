namespace DTO.Output.ApiResponses.Bases
{
    public abstract class ApiResponseBase
    {
        protected ApiResponseBase(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; }
    }
}
