using Common.Models.Responses;
using Contracts.IServices.Managers;
using DTO.Output.ApiResponses.Bases;
using Microsoft.AspNetCore.Http;

namespace RestfulApiHandler.Base
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api")]
    public abstract class AbstractApiVer01Controller : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IDomainServices _domainServices;

        public AbstractApiVer01Controller(ILogService logService, IDomainServices domainServices)
        {
            _logService = logService;
            _domainServices = domainServices;
        }

        public virtual IEntityServiceManager EntityServices => _domainServices.EntityServices;

        public virtual IIdentityServiceManager IdentityServices => _domainServices.IdentityServices;

        public virtual ILogService LogService => _logService;

        [NonAction]
        public IActionResult ProcessErrorResponse(ApiResponseBase apiResponse)
        {
            return apiResponse switch
            {
                ApiNotFoundResponse => NotFound(new ErrorResponseModel()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = ((ApiNotFoundResponse)apiResponse).Message
                }),
                ApiBadRequestResponse => BadRequest(new ErrorResponseModel()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ((ApiBadRequestResponse)apiResponse).Message
                }),
                _ => throw new NotImplementedException()
            };
        }

    }
}
