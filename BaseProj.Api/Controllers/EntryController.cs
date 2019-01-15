using BaseProj.Api.Treatments;
using BaseProj.Api.Treatments.Enums;
using BaseProj.Core.Entities;
using BaseProj.Core.Provider;
using BaseProj.Core.Utils;
using BaseProj.Entry;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BaseProj.Api.Controllers
{
    [Route("api/[controller]")]
    public class EntryController : Controller
    {
        private readonly IEntryModule entry;

        public EntryController(IEntryModule entry)
        {
            this.entry = entry;
        }

        [HttpPost("users/login")]
        public async Task<Return> Login([FromBody] User user)
        {
            try
            {
                if (await entry.UserAutenticatedAsync(user))
                    return new Success(Suc.SessionValidatedSuccessfully, user.Without("Password"), user.NewToken());
                else return new Error(Err.SessionNotValidated);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }
    }
}
