using Shared.CustomModels.DynamicObjects;

namespace Contracts.IDataShaper
{
    public interface IDataShaper<TModel>
    {
        IEnumerable<ShapedModel> ShapeData (IEnumerable<TModel> models, string fieldsStr);

        ShapedModel ShapeData(TModel model, string fieldsStr);

    }
}

