using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ExploringClientCredentialsFlow
{
    public static class SigningKey
    {
        public static SymmetricSecurityKey Secret
        {
            get
            {
                return new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Dit is geheim, bedoeld om JWT te ondertekenen"));
            }

        }
    }
}
