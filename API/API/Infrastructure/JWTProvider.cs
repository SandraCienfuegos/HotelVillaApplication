using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using API.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace API.Infrastructure
{
    public class JWTProvider
    {
        private const int TokenDurationInDays = 7;

        private const string SecretKey = "Rw00HMN4gqwWUMMBrHGYQANastYtl8Dn6";
        public static readonly byte[] SecretKeyBytes = Encoding.ASCII.GetBytes(SecretKey);
        private static readonly JwtSecurityTokenHandler JwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        public static string GenerateJWT(Customer customer)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, customer.Email),
                    new Claim(ClaimTypes.GivenName, customer.FirstName),
                    new Claim(ClaimTypes.Name, customer.CustomerId.ToString()),
                }),
                Expires = DateTime.Now.AddDays(TokenDurationInDays),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(SecretKeyBytes),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            return JwtSecurityTokenHandler.WriteToken(
                JwtSecurityTokenHandler.CreateToken(tokenDescriptor)
            );
        }

        public static Customer DecryptJWT(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(SecretKeyBytes),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);

            return new Customer
            {
                Email = claims.Claims.Single(x => x.Type == ClaimTypes.Email).Value,
                FirstName = claims.Claims.Single(x => x.Type == ClaimTypes.GivenName).Value,
                CustomerId = int.Parse(claims.Claims.Single(x => x.Type == ClaimTypes.Name).Value),
                Token = token,
            };
        }
    }
}