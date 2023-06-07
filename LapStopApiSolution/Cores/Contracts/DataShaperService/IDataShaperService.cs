using System.Dynamic;

namespace Contracts.DataShaperService
{
    public interface IDataShaperService<TAppliedModel, TReturnedDynamicObject>
    {
        IEnumerable<TReturnedDynamicObject> ExecuteShapingData (IEnumerable<TAppliedModel> dataModelCollection, string requiredPropsStr);
        TReturnedDynamicObject ExecuteShapingData(TAppliedModel dataModel, string requiredPropsStr);

    }
}

