using FicticiaSA.API.Data;
using FicticiaSA.API.Models;

namespace FicticiaSA.API.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public Client GetById(int id)
        {
            return _context.Clients.Find(id) ?? throw new KeyNotFoundException($"Client with id {id} not found.");
        }

        public void Add(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void Update(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var client = _context.Clients.Find(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }
    }
}