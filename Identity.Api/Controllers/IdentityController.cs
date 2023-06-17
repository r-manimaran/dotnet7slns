using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private const string TokenSecret = "MySecureTokenGenerationKey";
        private static readonly TimeSpan TokenLifeTime = TimeSpan.FromHours(4);
        [HttpPost("token")]
        public IActionResult GenerateToken([FromBody] TokenGenerationRequest request)
        {
            /*    var tokenHandler = new JwtSecurityTokenHandler();
                var key=Encoding.UTF8.GetBytes(TokenSecret);

                var claims = new List<Claim>
                {
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new(JwtRegisteredClaimNames.Sub, request.Email),
                    new(JwtRegisteredClaimNames.Email, request.Email),
                    new("userid",request.UserId.ToString())
                };

                foreach(var claimPair in request.CustomClaims)
                {
                    var jsonElement = (JsonElement)claimPair.Value;
                    var valueType = jsonElement.ValueKind switch
                    {
                        JsonValueKind.True => ClaimValueTypes.Boolean,
                        JsonValueKind.False => ClaimValueTypes.Boolean,
                        JsonValueKind.Number => ClaimValueTypes.Double,
                        _ => ClaimValueTypes.String 
                    };
                    var claim = new Claim(claimPair.Key, claimPair.Value);
                    claims.Add(claim);
                }
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.Add(TokenLifeTime),
                    Issuer = "https://id.rmanimaran.com",
                    Audience ="https://user.rmanimaran.com",
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), )
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                var jwt = tokenHandler.WriteToken(token);
                return Ok(jwt);*/
            return Ok();
        }

    }
}
