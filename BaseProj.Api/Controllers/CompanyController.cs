using BaseProj.Api.Treatments;
using BaseProj.Api.Treatments.Enums;
using BaseProj.Company;
using BaseProj.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BaseProj.Api.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyModule company;

        public CompanyController(ICompanyModule companyModule)
        {
            company = companyModule;
        }

        [HttpPost("clients")]
        public async Task<Response> RegisterUserAsync([FromBody] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clientResult = await company.RegisterClientAsync(client);
                    return new Success(Suc.ClientSuccessfullyRegistered, clientResult);
                }
                else return new Error(Err.InvalidPadding, ModelState.GetValidationObject());
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpDelete("clients/{id}/delete")]
        public async Task<Response> DeleteClientAsync(int id)
        {
            try
            {
                await company.DeleteClientAsync(id);
                return new Success(Suc.ClientDeletedSuccessfully);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpGet("clients")]
        public async Task<Response> ListAllClientsAsync()
        {
            try
            {
                var clients = await company.ListAllClientsAsync();

                if (clients.Length > 0) return new Success(clients);
                else return new Error(Err.NoClients);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpPut("clients/{id}")]
        public async Task<Response> UpdateClientAsync(int id, [FromBody] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clientResult = await company.UpdateClientAsync(id, client);
                    return new Success(Suc.ClientUpdatedSuccessfully, clientResult);
                }
                else return new Error(Err.InvalidPadding, ModelState.GetValidationObject());
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpGet("clients/{id}")]
        public async Task<Response> GetClientByIdAsync(int id)
        {
            try
            {
                var client = await company.GetClientByIdAsync(id);

                if (client != null)
                    return new Success(client);
                else return new Error(Err.ClientDoesNotExist);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpGet("properties/{property}/{value}/clients")]
        public async Task<Response> GetClientsByPropertyAsync(string property, string value)
        {
            try
            {
                var clients = await company.GetClientsByPropertyAsync(property, value);

                if (clients.Length > 0)
                    if (clients.Length == 1)
                        return new Success(Suc.OneClientFound, clients[0]);
                    else return new Success(clients);
                else return new Error(Err.ClientNotFound);
            }
            catch (Exception ex)
            {
                return new Error(ex);
                throw;
            }
        }
    }
}