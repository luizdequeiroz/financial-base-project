using BaseProj.Core.Entities;
using System.Linq;

namespace BaseProj.Core.Provider
{
    public static class TokenGenerate
    {
        public static string NewToken(this User user)
        {           
            var token = new TokenBuilder
            {
                SecurityKey = SecurityKey.Create("lllc.baseproj.dotnetcore"),
                Subject = user.Email,
                Issuer = "security.baseproj.com.br",
                Audience = "security.baseproj.com.br",
                ExpiryInMinutes = 5
            }
            .AddClaim("UserId", user.Id.ToString())
            .Build();

            return token.value;
        }
    }
}
