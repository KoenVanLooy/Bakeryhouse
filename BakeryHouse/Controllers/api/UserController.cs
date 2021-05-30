using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BakeryHouse.Areas.Identity.Data;
using BakeryHouse.Entities;
using BakeryHouse.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BakeryHouse.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly SignInManager<CustomUser> _signInManager;
        public readonly UserManager<CustomUser> _userManager;
        public readonly AppSettings _appSettings;

        public UserController( SignInManager<CustomUser> signInManager, UserManager<CustomUser> userManager, IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("authenticate")]
        public async Task<object> Authenticate([FromBody] ApiUser apiUser)
        {
            // kan er aangemeld worden
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(
                apiUser.UserName, apiUser.Password, false, false);
            //If statement wordt doorlopen als er aangemald kan worden
            if (signInResult.Succeeded)
            {
                CustomUser customUser = _userManager.Users.SingleOrDefault(r => r.Email == apiUser.UserName);
                apiUser.Token = GenerateJwtToken(apiUser.UserName, customUser).ToString();

                return apiUser;
            }
            return BadRequest(new { message = "Username or password is incorrect" });
           
        }

        private string GenerateJwtToken(string email, CustomUser user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
