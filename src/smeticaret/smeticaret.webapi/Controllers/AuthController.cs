using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using smeticaret.webapi.Models;
using smEticaret.Data.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace smeticaret.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _dbcontext;

        public AuthController(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbcontext = dbContext;
            _configuration = configuration;

        }

        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _dbcontext.Users.FirstOrDefault(x => x.email == loginModel.email);
            if(user is null)
            {
                return NotFound();

            }
            var hashedPassword = HashString(loginModel.password);
            if(user.passwordHash != hashedPassword)
            {
                return NotFound();
            }

            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Id, user.id.ToString()),
                new Claim(JwtClaimTypes.Name, user.name),
            };

            var tokenResult = GenerateToken(claims);

            return Ok(tokenResult);

        }
        private string HashString(string input)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(bytes);
        }
        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var tokenstring = "";
            try
            {
                var secret = _configuration.GetValue<string>("SecretKey");
                var issuers = _configuration.GetValue<string>("Issuers");
                var Audiences = _configuration.GetValue<string>("Audiences");
                var JwtExpirationMinutes = _configuration.GetValue<string>("JwtExpirationMinutes");
                if (string.IsNullOrWhiteSpace(secret))
                {
                   
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

                var claimsList = claims.ToList();

                foreach (var issuer in issuers)
                {
                    claimsList.Add(new(JwtClaimTypes.Issuer, issuer.ToString()));
                }


                foreach (var audience in Audiences)
                {
                    claimsList.Add(new(JwtClaimTypes.Audience, audience.ToString()));
                }

                var tokenOptions = new JwtSecurityToken(
                        claims: claimsList,
                        expires: DateTime.Now.AddMinutes(double.Parse(JwtExpirationMinutes)),
                        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    );

                 tokenstring = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return tokenstring;
            }
            catch (SecurityTokenEncryptionFailedException secEx)
            {
                return tokenstring;
            }


        }
    }
}
