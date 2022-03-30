using TriviumApiTest.Models;

namespace TriviumApiTest.Data
{
    public interface IClientsRepository
    {
        IEnumerable<Client> GetClients();
        Client GetClientById(int id);
        bool CreateClient(Client client);
        bool UpdateClient(Client client);
        bool DeleteClient(int id);
        IEnumerable<Purchase> GetPurchasesByClientId(int clientId);
        IEnumerable<Product> GetTopProductsBoughtByClient(int id, int limit);
    }
}
