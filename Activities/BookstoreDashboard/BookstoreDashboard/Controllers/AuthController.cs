using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookstoreDashboard.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Buffers.Text;
using System.ComponentModel;

namespace BookstoreDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration; // Injecting configuration for JWT settings
        }
        // POST api/Auth/login - Handles user login and JWT token generation
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            // Step 1: Validate user credentials (for demo purposes, using static values)
             if (user.Username == "admin" && user.Password == "password")
            {
                // Step 2: Generate a JWT token if credentials are valid
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Username) // Adding username as a claim
             }),
                Expires = DateTime.UtcNow.AddMinutes(30), // Token expiration time
                Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new
                SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor); //Create token based on descriptor
                 var tokenString = tokenHandler.WriteToken(token); //Write token as a string

                 // Return token to the client
                 return Ok(new { Token = tokenString });
            }
            // Step 3: Return unauthorized status if credentials are invalid
            return Unauthorized("Invalid credentials");
        }
    }
}
