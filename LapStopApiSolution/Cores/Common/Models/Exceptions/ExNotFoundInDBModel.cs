using Common.Functions;

namespace Common.Models.Exceptions
{
    public sealed class ExNotFoundInDBModel : Exception
    {
        public ExNotFoundInDBModel(string className, string methodName, Type notFoundModelType, object notFoundValue)
            : base(CommonFunctions.DisplayErrors.ReturnNotFoundInDatabaseMessage(className, methodName, notFoundModelType, notFoundValue))
        {

        }
    }
}
