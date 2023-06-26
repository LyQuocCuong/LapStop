using System.Dynamic;

namespace Contracts.Utilities.DataShaper
{
    public interface IDataShaperService<TAppliedModel, TReturnedDynamicObject>
    {
        IEnumerable<TReturnedDynamicObject> Execute(IEnumerable<TAppliedModel> dataModelCollection, string? requiredPropsStr);
        TReturnedDynamicObject Execute(TAppliedModel dataModel, string? requiredPropsStr);

    }
}

