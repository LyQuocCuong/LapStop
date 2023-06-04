using System.Dynamic;

namespace Contracts.DataShaper
{
    public interface IDataShaperService<TAppliedModel, TReturnedDynamicObject>
    {
        IEnumerable<TReturnedDynamicObject> ExecuteShapingData (IEnumerable<TAppliedModel> dataModelCollection, string requiredPropsStr);
        TReturnedDynamicObject ExecuteShapingData(TAppliedModel dataModel, string requiredPropsStr);

    }
}

