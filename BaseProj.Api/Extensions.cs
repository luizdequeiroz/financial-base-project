using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace BaseProj.Api
{
    static class Extensions
    {
        public static bool IsPublicMethod(this TokenValidatedContext context, IConfiguration Configuration)
        {
            var publics = Configuration.GetSection("PublicMethods").AsEnumerable();
            return publics.Select(p => p.Value).Contains(context.Request.Path.Value.Split('/')[2]);
        }
    }
}
