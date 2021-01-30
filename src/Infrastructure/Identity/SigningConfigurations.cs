using Hiro.Infrastructure.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace Hiro.Infrastructure.Identity
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations(TokenConfigurations tokenConfig)
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                var k = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfig.Key));
                Key = k;
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
