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

        [HttpPost("login/")]
        public async Task<Response> Login([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await entry.UserAutenticatedAsync(user))
                        return new Success(Suc.SessionValidatedSuccessfully, user.Without("Password"), user.NewToken());
                    else return new Error(Err.SessionNotValidated);
                }
                else
                {
                    return new Error(Err.InvalidPadding, ModelState.GetValidationObject());
                }
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpPost("users/")]
        public async Task<Response> RegisterUser([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userResult = await entry.RegisterUserAsync(user);
                    return new Success(Suc.UserSuccessfullyRegistered, userResult);
                }
                else
                {
                    return new Error(Err.InvalidPadding, ModelState.GetValidationObject());
                }
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpDelete("users/delete")]
        public async Task<Response> DeleteUser(int id)
        {
            try
            {
                await entry.DeleteUserAsync(id);
                return new Success(Suc.UserDeletedSuccessfully);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }
    }
}
