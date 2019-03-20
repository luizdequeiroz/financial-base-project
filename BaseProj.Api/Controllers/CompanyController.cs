using BaseProj.Api.Treatments;
using BaseProj.Api.Treatments.Enums;
using BaseProj.Company.Interfaces;
using BaseProj.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BaseProj.Api.Controllers
{
    [Authorize("UserAccess")]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly IClientRule clientRule;

        public CompanyController(IClientRule clientRule)
        {
            this.clientRule = clientRule;
        }

        [HttpPost("client")]
        public async Task<Response> RegisterClientAsync([FromBody] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clientResult = await clientRule.RegisterClientAsync(client);
                    return new Success(Suc.ClientSuccessfullyRegistered, clientResult);
                }
                else return new Error(Err.InvalidPadding, ModelState.GetValidationObject());
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpDelete("client/{id}/delete")]
        public async Task<Response> DeleteClientAsync(int id)
        {
            try
            {
                await clientRule.DeleteClientAsync(id);
                return new Success(Suc.ClientDeletedSuccessfully);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpGet("clients/{quantity?}")]
        public async Task<Response> ListClientsAsync(int quantity = 0)
        {
            try
            {
                var clients = await clientRule.ListClientsAsync(quantity);

                if (clients.Length > 0) return new Success(clients);
                else return new Error(Err.NoClients, clients);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpPut("client/{id}")]
        public async Task<Response> UpdateClientAsync(int id, [FromBody] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clientResult = await clientRule.UpdateClientAsync(id, client);
                    return new Success(Suc.ClientUpdatedSuccessfully, clientResult);
                }
                else return new Error(Err.InvalidPadding, ModelState.GetValidationObject());
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpGet("client/{id}")]
        public async Task<Response> GetClientByIdAsync(int id)
        {
            try
            {
                var client = await clientRule.GetClientByIdAsync(id);

                if (client != null)
                    return new Success(client);
                else return new Error(Err.ClientDoesNotExist);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpGet("property/{property}/{value}/clients")]
        public async Task<Response> GetClientsByPropertyAsync(string property, string value)
        {
            try
            {
                var clients = await clientRule.GetClientsByPropertyAsync(property, value);

                if (clients.Length > 0) return new Success(clients);
                else return new Error(Err.ClientNotFound);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }

        [HttpPost("import/clients")]
        public async Task<Response> RegisterClientsFromImportationAsync([FromBody] Client[] clients)
        {
            try
            {
                Client[] clientsResult = await clientRule.RegisterClientsAsync(clients);
                if (clientsResult.Length > 0) return new Success(clientsResult);
                else return new Error(Err.TheClientsWereNotRegistered);
            }
            catch (Exception ex)
            {
                return new Error(ex);
            }
        }
    }
}