using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using tryiiter.Constants;
using tryiiter.Models;

namespace tryiiter.Utils;

public class TokenGenerator
{
    /// <summary>
    /// This function is to Generate Token 
    /// </summary>
    /// <returns>A string, the token JWT</returns>
    public string Generate(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = AddClaims(user),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)),
                SecurityAlgorithms.HmacSha256Signature
            ),
            Expires = DateTime.Now.AddDays(1)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
    
    /// <summary>
    /// Function that adds the claims to the token
    /// </summary>
    private ClaimsIdentity AddClaims(User user)
    {
        var claims = new ClaimsIdentity();
            
        claims.AddClaim(new Claim("Name", user.Name));
        claims.AddClaim(new Claim("Email", user.Email));
        claims.AddClaim(new Claim("Password", user.Password));

        return claims;
    }
}