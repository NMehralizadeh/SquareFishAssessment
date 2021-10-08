using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace SquareFish.Assessment.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("token"), AllowAnonymous]
        public IActionResult RequestToken([FromBody] TokenRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = Authenticate(request.Username, request.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = GetJwtSecurityToken(user);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        private UserModel Authenticate(string username, string password) =>
            // For simple authentication we just compare username and password
            username.Equals(password)
                ? new UserModel
                {
                    Id = 110,
                    Name = "Navid M.Alizadeh",
                    Email = "n.mehralizadeh@squarefish.ie",
                }
                : default(UserModel);

        private JwtSecurityToken GetJwtSecurityToken(UserModel user)
        {
            var claims = new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return token;
        }
    }

    public class TokenRequestModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
    }
}