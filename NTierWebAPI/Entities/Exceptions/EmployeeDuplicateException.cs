
namespace Entities.Exceptions 
{ 
    public class EmployeeDuplicateException : Exception
    {
        public EmployeeDuplicateException(int employeeID)
            : base($"Employee with the ID of '{employeeID}' already exists.")
        {
            
        }
    }
}
