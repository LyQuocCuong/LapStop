using Shared.Common.Messages;

namespace Shared.CustomModels.Exceptions
{
    public sealed class ExNotFoundInDB : Exception
    {
        public ExNotFoundInDB(string className, string methodName, Type notFoundModelType, object notFoundValue)
            : base(CommonMessages.ERROR.NotFoundInDatabase(className, methodName, notFoundModelType, notFoundValue))
        {

        }

    }
}
