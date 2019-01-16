using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public static dynamic GetValidationObject(this ModelStateDictionary ModelState) =>
            ModelState.Select(v => new
            {
                Input = v.Key,
                Msgs = v.Value.Errors.Select(e => e.ErrorMessage)
            });
    }
}
