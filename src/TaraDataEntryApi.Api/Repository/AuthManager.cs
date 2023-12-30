using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TARA.DATAENTRY.API.Contracts;
using TARA.DATAENTRY.API.Data;
using TARA.DATAENTRY.API.Models.Users;

namespace TARA.DATAENTRY.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly IConfiguration configuration;
        private AppUser user;
        private const string loginProvider = "TARADataEntryAPI";
        private const string refreshToken = "RefreshToken";

        public AuthManager(IMapper mapper,UserManager<AppUser> userManager,IConfiguration configuration)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<string> CreateRefreshToken()
        {
            await userManager.RemoveAuthenticationTokenAsync(user,loginProvider,refreshToken);
            var newRefreshToken = await userManager.GenerateUserTokenAsync(user, loginProvider, refreshToken); 
            var result = await userManager.SetAuthenticationTokenAsync(user, loginProvider, refreshToken, newRefreshToken);
            return newRefreshToken;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            bool isValidCredentials = false;
               user = await userManager.FindByEmailAsync(loginDto.Email);

            if (user != null)
            {
                isValidCredentials = await userManager.CheckPasswordAsync(user, loginDto.Password);
                if (!isValidCredentials)
                {
                    return null;
                }

            }
            var token =await GenerateToken();

            return new AuthResponseDto
            {
                Token = token,
                Userid = user.Id,
                RefreshToken=await CreateRefreshToken()
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(RegisterUserDto registerUserDto)
        {
             user = mapper.Map<AppUser>(registerUserDto);
            user.UserName = registerUserDto.Email;
            var result = await userManager.CreateAsync(user,registerUserDto.Password);
            if (result.Succeeded)
            {
                if (registerUserDto.Roles != null && registerUserDto.Roles.Any())
                {
                    result = await userManager.AddToRolesAsync(user, registerUserDto.Roles);
                }
            }
          return result.Errors;
        }

        public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            var jwtSecuriyTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent=jwtSecuriyTokenHandler.ReadJwtToken(request.Token);    
            var userName=tokenContent.Claims.ToList().FirstOrDefault(x=>x.Type==
            JwtRegisteredClaimNames.Sub)?.Value;
            user = await userManager.FindByNameAsync(userName);
            if (user==null || user.Id!= request.Userid)
            {
                return null;
                
            }
            var isValidRefreshToken = await userManager.VerifyUserTokenAsync(user, loginProvider, refreshToken,
                request.RefreshToken);
            if(isValidRefreshToken)
            {
                var token = await GenerateToken();
                return new AuthResponseDto
                {
                    Token = token,
                    Userid= user.Id,
                    RefreshToken=await CreateRefreshToken(),
                };
            }
            await userManager.UpdateSecurityStampAsync(user);
            return null;


        }

        private async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims=roles.Select(x=> new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims=await userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id)

            }.Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials:credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);


        }
        
    }
}
