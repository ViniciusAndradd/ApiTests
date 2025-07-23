using ApiTest.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Repositories
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>>GetAllClients();
        public Task<Client?> GetClient(int id);
        public Task<IEnumerable<Client>> GetClientByName(string name);
        public Task AddClient(Client client);
        public Task RemoveClient(Client client);
        public Task UpdateClient(Client client);
        public Task SaveChanges();
    }
}
