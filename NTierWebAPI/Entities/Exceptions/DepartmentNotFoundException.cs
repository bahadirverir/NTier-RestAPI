
namespace Entities.Exceptions 
{
    public sealed class DepartmentNotFoundException : NotFoundException
    {
        public DepartmentNotFoundException(int id) 
            : base($"The Department with id : {id} could not found")
        {
            
        }
    }
}
