using TriviumApiTest.Models;

namespace TriviumApiTest.Data
{
    public class MockClientsRepository : IClientsRepository
    {
        public Client GetClientById(int id)
        {
            return new Client() { Id = id, Name = $"Cliente{id}", Address = $"Endereco{id}", PhoneNumber = $"Telefone{id}" };
        }

        public IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client() { Id = 1, Name = "Cliente1", Address = "Endereco1", PhoneNumber = "Telefone1" },
                new Client() { Id = 2, Name = "Cliente2", Address = "Endereco2", PhoneNumber = "Telefone2" },
                new Client() { Id = 3, Name = "Cliente3", Address = "Endereco3", PhoneNumber = "Telefone3" },
            };
        }

        public bool CreateClient(Client client)
        {
            return true;
        }

        public bool UpdateClient(Client client)
        {
            return true;
        }

        public bool DeleteClient(int id)
        {
            return true;
        }

        public IEnumerable<Purchase> GetPurchasesByClientId(int clientId)
        {
            return new List<Purchase>()
            {
                new Purchase() {
                    Id = 1,
                    ClientId = clientId,
                    Items = new List<PurchaseItem>()
                    {
                        new PurchaseItem() { Id = 1, PurchaseId = 1, ProductId = 1, Quantity = 2,
                            Product = new Product() { Id = 1, Name = "Product 1", Price = 5.50 } },
                        new PurchaseItem() { Id = 1, PurchaseId = 1, ProductId = 2, Quantity = 10,
                            Product = new Product() { Id = 2, Name = "Product 2", Price = 1.5 } },
                    }
                },
                new Purchase() {
                    Id = 2,
                    ClientId = clientId,
                    Items = new List<PurchaseItem>()
                    {
                        new PurchaseItem() { Id = 1, PurchaseId = 2, ProductId = 1, Quantity = 4,
                            Product = new Product() { Id = 1, Name = "Product 1", Price = 5.50 } },
                        new PurchaseItem() { Id = 1, PurchaseId = 2, ProductId = 3, Quantity = 1,
                            Product = new Product() { Id = 2, Name = "Product 3", Price = 10 } },
                    }
                },
            };
        }

        public IEnumerable<Product> GetTopProductsBoughtByClient(int id, int limit)
        {
            var products = new List<Product>();

            for(int i = 0; i < limit; i++)
            {
                products.Add(GenerateProduct(i + 1));
            }
            
            return products;
        }

        private Product GenerateProduct(int id)
        {
            return new Product()
            {
                Id = id,
                Name = $"Product {id}",
                Price = id * 2 + 0.99
            };
        }
    }
}
