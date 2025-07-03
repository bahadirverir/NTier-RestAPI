
namespace Entities.Exceptions 
{
    public sealed class DepartmentDuplicateException : Exception
    {
        public DepartmentDuplicateException(string fieldName1, string fieldValue1, string fieldName2, string fieldValue2)
            : base($"A department with the same '{fieldName1}' value '{fieldValue1}' and '{fieldName2}' value '{fieldValue2}' already exists.")
        {
        }

        public DepartmentDuplicateException(string fieldName, string fieldValue)
            : base($"A department with the same '{fieldName}' value '{fieldValue}' already exists.")
        {
        }
    }
}