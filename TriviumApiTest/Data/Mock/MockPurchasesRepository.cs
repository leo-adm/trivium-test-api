using TriviumApiTest.Models;

namespace TriviumApiTest.Data
{
    public class MockPurchasesRepository : IPurchasesRepository
    {
        public IEnumerable<Purchase> GetPurchases()
        {
            return new List<Purchase>()
            {
                new Purchase() { Id = 1, ClientId = 1 },
                new Purchase() { Id = 2, ClientId = 1 },
                new Purchase() { Id = 3, ClientId = 2 },
            };
        }
    }
}
