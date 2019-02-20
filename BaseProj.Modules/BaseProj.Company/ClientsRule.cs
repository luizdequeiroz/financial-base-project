using BaseProj.Company.Interfaces;
using BaseProj.Core.Entities;
using BaseProj.Core.Exceptions;
using BaseProj.Core.Repository;
using BaseProj.Core.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProj.Company
{
    public partial class CompanyModule : ICompanyModule
    {
        private readonly IGenericRepository<Client> clientRepository;

        public CompanyModule(IGenericRepository<Client> genericRepository)
        {
            clientRepository = genericRepository;
        }

        public async Task<Client> RegisterClientAsync(Client client)
        {
            return await clientRepository.InsertAsync(client);
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await clientRepository.SelectByIDAsync(id);
            await clientRepository.DeleteAsync(client);
        }

        public async Task<Client[]> ListClientsAsync(int quantity)
        {
            var clients = await clientRepository.SelectAllAsync();
            if (quantity > 0) clients = clients.OrderByDescending(c => c.Id).Take(quantity);
            return clients.ToArray();
        }

        public async Task<Client> UpdateClientAsync(int id, Client client)
        {
            var cl = await clientRepository.SelectByIDAsync(id);
            client.ApplyProperties(ref cl);
            await clientRepository.UpdateAsync(cl);
            return cl;
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            var client = await clientRepository.SelectByIDAsync(id);
            return client;
        }

        public async Task<Client[]> GetClientsByPropertyAsync(string property, object value)
        {
            var client = new List<Client>().ToArray();
            if (property == "id")
                client = (await clientRepository.SelectWhereAsync(c => c.Id == (int)value)).ToArray();
            else if (property == "name")
                client = (await clientRepository.SelectWhereAsync(c => c.Name.ToLower().Contains(value.ToString().ToLower()))).ToArray();
            else if (property == "rg")
                client = (await clientRepository.SelectWhereAsync(c => c.RG == value.ToString())).ToArray();
            else if (property == "cpf")
                client = (await clientRepository.SelectWhereAsync(c => c.CPF == value.ToString())).ToArray();
            else if (property == "birthDate")
                client = (await clientRepository.SelectWhereAsync(c => c.BirthDate.Date == (value as string).ToDateTime().Date)).ToArray();
            else if (property == "phone")
                client = (await clientRepository.SelectWhereAsync(c => c.Phone == value.ToString() || c.Cell == value.ToString())).ToArray();
            else if (property == "email")
                client = (await clientRepository.SelectWhereAsync(c => c.Email.ToLower().Contains(value.ToString().ToLower()))).ToArray();
            else if (property == "type")
                client = (await clientRepository.SelectWhereAsync(c => c.Type == (int)value)).ToArray();
            else if (property == "bank")
                client = (await clientRepository.SelectWhereAsync(c => c.Bank.ToLower().Contains(value.ToString().ToLower()))).ToArray();
            else throw new ArgumentPropertyException(property);

            return client;
        }

        public async Task<Client[]> RegisterClientsAsync(Client[] clients)
        {
            var clnts = await clientRepository.BulkInsertAsync(clients.AsQueryable());
            return clnts.ToArray();
        }
    }
}
