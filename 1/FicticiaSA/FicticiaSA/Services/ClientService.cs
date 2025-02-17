using FicticiaSA.API.Models;
using FicticiaSA.API.Repositories;

namespace FicticiaSA.API.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _clientRepository.GetAll();
        }

        public Client GetClientById(int id)
        {
            return _clientRepository.GetById(id);
        }

        public void AddClient(Client client)
        {
            _clientRepository.Add(client);
        }

        public void UpdateClient(Client client)
        {
            _clientRepository.Update(client);
        }

        public void DeleteClient(int id)
        {
            _clientRepository.Delete(id);
        }
    }
}