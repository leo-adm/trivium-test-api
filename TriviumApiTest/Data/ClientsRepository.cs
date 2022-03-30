using TriviumApiTest.Models;

namespace TriviumApiTest.Data
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly TriviumTestApiDbContext _context;

        public ClientsRepository(TriviumTestApiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Clients.ToList();
        }

        public Client GetClientById(int id)
        {
            return _context.Clients.FirstOrDefault(c => c.Id == id);
        }

        public bool CreateClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateClient(Client client)
        {
            try
            {
                _context.Clients.Update(client);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteClient(int id)
        {
            try
            {
                var client = _context.Clients.FirstOrDefault(c => c.Id == id);
                if (client == null)
                    return false;

                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<Purchase> GetPurchasesByClientId(int clientId)
        {
            return _context.Clients.First(c => c.Id == clientId).Purchases;
        }

        public IEnumerable<Product> GetTopProductsBoughtByClient(int id, int limit)
        {
            var productIdQuantity = new Dictionary<int, int>();

            var clientPurchases = GetClientById(id).Purchases;
            clientPurchases.ForEach(purchase =>
                purchase.Items.ForEach(item =>
                {
                    if(!productIdQuantity.ContainsKey(item.ProductId))
                        productIdQuantity.Add(item.ProductId, 0);

                    productIdQuantity[item.ProductId] += item.Quantity;
                }));

            var mostBoughtIds = productIdQuantity.OrderByDescending(x => x.Value)
                .Take(limit).Select(x => x.Key);

            return _context.Products.Where(x => mostBoughtIds.Contains(x.Id)).ToList();
        }

    }
}
