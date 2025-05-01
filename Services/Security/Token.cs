using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NetStock.Entities;

namespace NetStock.Services
{
    public class TokenService
    {
        private readonly IConfiguration configuration;
        public TokenService(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        public string GenerateToken(User user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentialss = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]{
            new Claim(ClaimTypes.NameIdentifier,user.UserID.ToString()),
            new Claim(ClaimTypes.Name,user.Name.ToString()),
            new Claim(ClaimTypes.Email,user.Email.ToString())

        };

            var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(3),
            signingCredentials: credentialss);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}