﻿using BaseProj.Core.Entities;
using System.Threading.Tasks;

namespace BaseProj.Company.Interfaces
{
    public interface IClientRule
    {
        Task<Client> RegisterClientAsync(Client client);

        Task DeleteClientAsync(int id);

        Task<Client[]> ListClientsAsync(int quantity);

        Task<Client> UpdateClientAsync(int id, Client client);

        Task<Client> GetClientByIdAsync(int id);

        Task<Client[]> GetClientsByPropertyAsync(string property, object value);

        Task<Client[]> RegisterClientsAsync(Client[] clients);        
    }
}
