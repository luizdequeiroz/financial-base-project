using BaseProj.Api.Treatments;
using BaseProj.Api.Treatments.Enums;
using BaseProj.Core.Entities;
using BaseProj.Core.Provider;
using BaseProj.Core.Utils;
using BaseProj.Entry.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProj.Api.Controllers
{
    [Authorize("UserAccess")]
    [Route("api/[controller]")]
    public class EntryController : Controller
    {
        private readonly IUserRule userRule;

        public EntryController(IUserRule userRule)
        {
            this.userRule = userRule;
        }

        [AllowAnonymous]
        [HttpGet("~/")]
        public IActionResult HelloWorld()
        {
            return Ok("Hello World");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<Response> LoginAsync([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                    if (await userRule.UserAutenticatedAsync(user))
                    {
                        user = (await userRule.GetUsersByPropertyAsync("email", user.Email)).FirstOrDefault();
                        return new Success(Suc.SessionValidatedSuccessfully, user.Without("Password"), user.NewToken());
                    }
                    else return new Error(Err.SessionNotValidated);
                else return new Error(Err.InvalidPadding, ModelState.GetValidationObject());
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("user")]
        public async Task<Response> RegisterUserAsync([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userResult = await userRule.RegisterUserAsync(user);
                    return new Success(Suc.UserSuccessfullyRegistered, userResult);
                }
                else return new Error(Err.InvalidPadding, ModelState.GetValidationObject());
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpDelete("user/{id}/delete")]
        public async Task<Response> DeleteUserAsync(int id)
        {
            try
            {
                await userRule.DeleteUserAsync(id);
                return new Success(Suc.UserDeletedSuccessfully);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("users/{quantity?}")]
        public async Task<Response> ListUsersAsync(int quantity = 0)
        {
            try
            {
                var users = await userRule.ListUsersAsync(quantity);

                if (users.Length > 0) return new Success(users);
                else return new Error(Err.NoUsers);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpPut("user/{id}")]
        public async Task<Response> UpdateUserAsync(int id, [FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userResult = await userRule.UpdateUserAsync(id, user);
                    return new Success(Suc.UserUpdatedSuccessfully, userResult);
                }
                else return new Error(Err.InvalidPadding, ModelState.GetValidationObject());
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("user/{id}")]
        public async Task<Response> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await userRule.GetUserByIdAsync(id);

                if (user != null)
                    return new Success(user);
                else return new Error(Err.UserDoesNotExist);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("property/{property}/{value}/users")]
        public async Task<Response> GetUsersByPropertyAsync(string property, string value)
        {
            try
            {
                var users = await userRule.GetUsersByPropertyAsync(property, value);

                if (users.Length > 0) return new Success(users);
                else return new Error(Err.UserNotFound);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }
    }
}
