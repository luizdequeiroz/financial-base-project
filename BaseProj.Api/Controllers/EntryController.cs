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

        public EntryController(IEntryModule entryModule)
        {
            entry = entryModule;
        }

        [HttpPost("login")]
        public async Task<Response> LoginAsync([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                    if (await entry.UserAutenticatedAsync(user))
                        return new Success(Suc.SessionValidatedSuccessfully, user.Without("Password"), user.NewToken());
                    else return new Error(Err.SessionNotValidated);
                else return new Error(Err.InvalidPadding, ModelState.GetValidationObject());
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpPost("users")]
        public async Task<Response> RegisterUserAsync([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userResult = await entry.RegisterUserAsync(user);
                    return new Success(Suc.UserSuccessfullyRegistered, userResult);
                }
                else return new Error(Err.InvalidPadding, ModelState.GetValidationObject());
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpDelete("users/{id}/delete")]
        public async Task<Response> DeleteUserAsync(int id)
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

        [HttpGet("users")]
        public async Task<Response> ListAllUsersAsync()
        {
            try
            {
                var users = await entry.ListAllUsersAsync();

                if (users.Length > 0) return new Success(users);
                else return new Error(Err.NoUsers);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpPut("users/{id}")]
        public async Task<Response> UpdateUserAsync(int id, [FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userResult = await entry.UpdateUserAsync(id, user);
                    return new Success(Suc.UserUpdatedSuccessfully, userResult);
                }
                else return new Error(Err.InvalidPadding, ModelState.GetValidationObject());
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpGet("users/{id}")]
        public async Task<Response> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await entry.GetUserByIdAsync(id);

                if (user != null)
                    return new Success(user);
                else return new Error(Err.UserDoesNotExist);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpGet("properties/{property}/{value}/users")]
        public async Task<Response> GetUsersByPropertyAsync(string property, string value)
        {
            try
            {
                var users = await entry.GetUsersByPropertyAsync(property, value);

                if (users.Length > 0)
                    if (users.Length == 1)
                        return new Success(Suc.OneUserFound, users[0]);
                    else return new Success(users);
                else return new Error(Err.UserNotFound);
            }
            catch (Exception ex)
            {
                return new Error(ex);
                throw;
            }
        }
    }
}
