using TriviumApiTest.Models;

namespace TriviumApiTest.Data
{
    public interface IClientsRepository
    {
        IEnumerable<Client> GetClients();
        Client GetClientById(int id);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
        IEnumerable<Purchase> GetPurchasesByClientId(int clientId);
        IEnumerable<Product> GetTopProductsBoughtByClient(int id, int limit);
    }
}
