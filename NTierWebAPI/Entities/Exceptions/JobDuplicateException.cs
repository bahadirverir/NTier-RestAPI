
namespace Entities.Exceptions 
{
    public class JobDuplicateException : Exception
    {
        public JobDuplicateException(string fieldName1, string fieldValue1, string fieldName2, string fieldValue2)
            : base($"A Job with the same '{fieldName1}' value '{fieldValue1}' and '{fieldName2}' value '{fieldValue2}' already exists.")
        {
        }

        public JobDuplicateException(string fieldName, string fieldValue)
            : base($"A Job with the same '{fieldName}' value '{fieldValue}' already exists.")
        {
        }
    }
}
