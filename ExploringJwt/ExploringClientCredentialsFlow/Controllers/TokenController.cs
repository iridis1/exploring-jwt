using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ExploringClientCredentialsFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        [HttpGet(Name = "token")]
        public string getToken()
        {

            var claims = new Dictionary<string, object>()
            {
                ["bank.name"] = "Rabobank",
                ["user.accountNumber"] = "NL01RABO092373481",
                ["user.fullName"] = "A.B. Caty",
                ["user.city"] = "Rotterdam"
            };

            var descriptor = new SecurityTokenDescriptor()
            {
                Issuer = "Issuex",
                Audience = "Audix",
                Claims = claims,
                IssuedAt = null,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = new SigningCredentials(SigningKey.Secret, SecurityAlgorithms.HmacSha256Signature),
            };

            var handler = new Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler();
            handler.SetDefaultTimesOnTokenCreation = false;
            return handler.CreateToken(descriptor);
        }

    }
}
