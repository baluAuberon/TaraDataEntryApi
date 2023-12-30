using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using TARA.DATAENTRY.API.Models.Users;

namespace TARA.DATAENTRY.API.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(RegisterUserDto registerUserDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto authResponseDto );
    }
}
