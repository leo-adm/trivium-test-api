using TriviumApiTest.Models;

namespace TriviumApiTest.Data
{
    public interface IPurchasesRepository
    {
        IEnumerable<Purchase> GetPurchases();
    }
}
