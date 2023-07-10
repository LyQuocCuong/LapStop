using Common.Functions;
using DTO.Output.ApiResponses.Bases;

namespace DTO.Output.ApiResponses.ErrorBadRequest
{
    public sealed class EmployeeInvaidAgeRangeBadRequestResponse : ApiBadRequestResponse
    {
        public EmployeeInvaidAgeRangeBadRequestResponse()
            : base(CommonFunctions.DisplayErrors.ReturnInvalidAgeRangeMessage)
        {
        }
    }
}
