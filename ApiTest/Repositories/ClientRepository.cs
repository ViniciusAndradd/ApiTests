using ApiTest.Context;
using ApiTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddClient(Client client)
        {
            await _context.Clients.AddAsync(client);
            SaveChanges();
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _context.Clients
                .Select(client => new Client
                {
                    Id = client.Id,
                    Name = client.Name,
                    Salary = client.Salary
                }).ToListAsync();
        }

        public async Task<Client> GetClient(int id)
        {
            return await _context.Clients
                .FindAsync(id);

        }

        public async Task<IEnumerable<Client>> GetClientByName(string name)
        {
            return await _context.Clients
                .Select(client => new Client
                {
                    Id = client.Id,
                    Name = client.Name,
                    Salary = client.Salary
                })
                .Where(c => c.Name.Contains(name))
                .ToListAsync();
        }

        public Task RemoveClient(Client client)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
