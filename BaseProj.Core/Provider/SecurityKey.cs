using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BaseProj.Core.Provider
{
    public class SecurityKey
    {
        public static SymmetricSecurityKey Create(string secret) => 
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
    }
}