using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace Services.Abstract
{
    public interface ICustomAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task RevokeRefreshToken(string username);
    }
}
