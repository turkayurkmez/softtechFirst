using eshop.API.Models;
using eshop.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using IdentityToken = System.IdentityModel.Tokens.Jwt;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.ValidateUser(userLogin.UserName, userLogin.Password);
                if (user != null)
                {
                    Claim[] claims =
                    {
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BU-CUMLE-ANAHTAR-CUMLE"));
                    var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new IdentityToken.JwtSecurityToken
                        (issuer: "api.softtech",
                         audience: "client",
                         claims: claims,
                         notBefore: DateTime.UtcNow,
                         expires: DateTime.UtcNow.AddDays(1),
                         signingCredentials: credential
                        );

                    return Ok(new { token = new IdentityToken.JwtSecurityTokenHandler().WriteToken(token) });
                }
                ModelState.AddModelError("login", "Kullanıcı adı vaye şifre yanlış!");
            }
            return BadRequest(ModelState);
        }
    }
}
