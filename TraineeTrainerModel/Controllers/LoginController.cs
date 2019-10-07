using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TraineeTrainerModel.Dal;
using TraineeTrainerModel.Models;
using TraineeTrainerModel.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace TraineeTrainerModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET: api/Login
        private CredentialService _service;
        private IConfiguration _configuration;

        public LoginController(CredentialService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }
        

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (_service.Exist(loginModel.Username))
                return NotFound(new { Error = "User not found" });
            var user = _service.Authenticate(loginModel.Username, loginModel.Password);
            IActionResult response = Unauthorized();

            if (user == null) return response;

            var tokenString = GenerateJSONWebToken(user);
            response = Ok(new { token = tokenString });
            return response;
            
        }
        

        private string GenerateJSONWebToken(UserCredential user)
        {
            var role = user.Role;
            Console.WriteLine(role.ToString());
            IdentityOptions _options = new IdentityOptions();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                        new Claim("UserID",user.Id),
                        new Claim(_options.ClaimsIdentity.RoleClaimType, role)
                   }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }
        
    }
}
