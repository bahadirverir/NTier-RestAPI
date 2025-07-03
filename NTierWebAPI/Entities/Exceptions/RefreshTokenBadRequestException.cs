
namespace Entities.Exceptions 
{
    public class RefreshTokenBadRequestException : Exception
    {
        public RefreshTokenBadRequestException() : base("İnvalid Client Request. Token has invalid values.")
        {
            
        }
    }
}
