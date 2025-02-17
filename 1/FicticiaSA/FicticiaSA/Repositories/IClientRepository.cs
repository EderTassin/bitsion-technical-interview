using FicticiaSA.API.Models;

namespace FicticiaSA.API.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetById(int id);
        Task Add(Client client);
        Task Update(Client client);
        Task Delete(int id);
    }
}