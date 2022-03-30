using TriviumApiTest.Models;

namespace TriviumApiTest.Data
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsWithPurchasesInfo();
        Product GetProductWithPurchasesInfo(int id);
    }
}
