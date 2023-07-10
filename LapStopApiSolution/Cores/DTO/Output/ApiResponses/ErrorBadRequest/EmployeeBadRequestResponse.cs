using DTO.Output.ApiResponses.Bases;

namespace DTO.Output.ApiResponses.ErrorBadRequest
{
    public sealed class EmployeeBadRequestResponse : ApiBadRequestResponse
    {
        public EmployeeBadRequestResponse(string message)
            : base(message)
        {
        }
    }
}
