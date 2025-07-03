
namespace Entities.Exceptions 
{
    public sealed class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(int id) 
            : base($"Employee with id : {id} could not found")
        {

        }
    }
}