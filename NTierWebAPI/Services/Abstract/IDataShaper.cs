using System.Dynamic;

namespace Services.Abstract
{ 
    public interface IDataShaper<T>
    {
        IEnumerable<ExpandoObject>  ShapeData(IEnumerable<T> entities, string fieldsString);
        ExpandoObject ShapeData(T entities, string fieldsString);
    }
}
