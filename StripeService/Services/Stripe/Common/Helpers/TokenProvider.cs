using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace StripeService.Services.Stripe.Common.Helpers
{
    public interface ITokenProvider
    {
        Task<string> GenerateTokenAsync(string userId);
        Task<ClaimsPrincipal?> ValidateTokenAsync(string token);
    }

    public class TokenProvider : ITokenProvider
    {
        private readonly string _jwtSecret;
        public TokenProvider(string jwtSecret)
        {
            _jwtSecret = jwtSecret;
        }

        public Task<string> GenerateTokenAsync(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, userId) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult(tokenHandler.WriteToken(token));
        }

        public Task<ClaimsPrincipal?> ValidateTokenAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out _);
                return Task.FromResult<ClaimsPrincipal?>(principal);
            }
            catch
            {
                return Task.FromResult<ClaimsPrincipal?>(null);
            }
        }
    }
}
