using FicticiaSA.API.Models;

namespace FicticiaSA.API.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> GetClientById(int id);
        Task AddClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(int id);
    }
}
