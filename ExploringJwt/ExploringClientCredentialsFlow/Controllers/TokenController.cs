using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ExploringClientCredentialsFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        [HttpGet(Name = "token")]
        public string CreateToken()
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
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = new SigningCredentials(SigningKey.Secret, SecurityAlgorithms.HmacSha256Signature),
            };

            var handler = new Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler();
            handler.SetDefaultTimesOnTokenCreation = true;
            return handler.CreateToken(descriptor);
        }

    }
}
