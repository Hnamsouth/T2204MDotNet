using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.DTOs;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [ApiController,Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly Sem3DotnetApiContext _context;
        public AuthController(Sem3DotnetApiContext context) { _context = context; }

        [HttpPost,Route("register-user")]
        public IActionResult Register(UserRegister data)
        {
            if (ModelState.IsValid)
            {
                var ec_pw = BCrypt.Net.BCrypt.HashPassword(data.Password);
                var nu = new User { Email = data.Email, Username = data.Username, Password = ec_pw };
                _context.Users.Add(nu);
                _context.SaveChanges();
                return Ok(new UserData { Email=data.Email,Username=data.Username,Token= "1adasd" });
            }
            return BadRequest(ModelState);
        }
     /*   public String GenerateJWT(User u)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var signatureKey = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email)
            };
            var token = new JwtSecurityToken(
                _config["JWT:Issuer"],
                _config["JWT:Audience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: signatureKey
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
            return "Asd";
        }*/

        [HttpGet]
        public IActionResult getUser()
        {
            var u = _context.Users.ToArray();
            List<UserData> users = new List<UserData>();
            foreach (var i in u)
            {
                users.Add(new UserData { Email = i.Email, Id = i.Id, Username = i.Username });
            }
            return Ok(users);
        }

        [HttpPost,Route("")]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}
