using BaseProj.Core.Entities;
using System.Threading.Tasks;

namespace BaseProj.Company
{
    public interface ICompanyModule
    {
        Task<Client> RegisterClientAsync(Client client);

        Task DeleteClientAsync(int id);

        Task<Client[]> ListAllClientsAsync();

        Task<Client> UpdateClientAsync(int id, Client client);

        Task<Client> GetClientByIdAsync(int id);

        Task<Client[]> GetClientsByPropertyAsync(string property, object value);
    }
}
