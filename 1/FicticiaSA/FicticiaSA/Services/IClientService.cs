using FicticiaSA.API.Models;

namespace FicticiaSA.API.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int id);
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
    }
}
