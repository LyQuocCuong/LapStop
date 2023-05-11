using System.Dynamic;

namespace Contracts.IDataShaper
{
    public interface IDataShaper<TModel>
    {
        IEnumerable<ExpandoObject> ShapeData (IEnumerable<TModel> models, string fieldsStr);

        ExpandoObject ShapeData(TModel model, string fieldsStr);

    }
}

