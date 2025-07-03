
namespace Entities.Exceptions 
{
    public sealed class JobNotFoundException : NotFoundException
    {
        public JobNotFoundException(int id) 
            : base($"Job with id : {id} could not found")
        {

        }
    }
}