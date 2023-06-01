using Common.Models.DynamicObjects;

namespace Contracts.IDataShaper
{
    public interface IDataShaperService<TModel>
    {
        IEnumerable<DynamicModel> ShapingData (IEnumerable<TModel> models, string fieldsStr);

        DynamicModel ShapingData(TModel model, string fieldsStr);

    }
}

