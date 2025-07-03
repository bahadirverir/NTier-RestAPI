
namespace Entities.DataTransferObjects 
{
    public record TokenDto 
    {
        public String AccesToken { get; init; }
        public String RefreshToken { get; init; }
    }
}
