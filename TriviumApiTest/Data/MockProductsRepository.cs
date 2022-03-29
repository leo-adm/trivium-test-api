using TriviumApiTest.Models;

namespace TriviumApiTest.Data
{
    public class MockProductsRepository : IProductsRepository
    {
        private static Random random = new Random(31251215);
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product { Id = 1, Name = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops", Price = 109.95 },
                new Product { Id = 2, Name = "Mens Casual Premium Slim Fit T-Shirts", Price = 22.33 },
                new Product { Id = 3, Name = "Mens Cotton Jacket", Price = 55.99 },
                new Product { Id = 4, Name = "Mens Casual Slim Fit", Price = 15.99 },
                new Product { Id = 5, Name = "John Hardy Women's Legends Naga Gold & Silver Dragon Station Chain Bracelet", Price = 695 },
                new Product { Id = 6, Name = "Solid Gold Petite Micropave", Price = 168 }
            };
        }

        public IEnumerable<Product> GetProductsWithPurchasesInfo()
        {
            return new List<Product>()
            {
                GetMockProduct(1, 5.90),
                GetMockProduct(2, 10.50),
                GetMockProduct(3, 3),
            };
        }

        public Product GetProductWithPurchasesInfo(int id)
        {
            return GetMockProduct(id, 10);
        }

        private Product GetMockProduct(int id, double price)
        {
            var GetProduct = () =>
            {
                return new Product()
                {
                    Id = id,
                    Name = $"Product {id}",
                    Price = price
                };
            };

            var product = GetProduct();

            var purchaseItems = new List<PurchaseItem>()
            {
                new PurchaseItem() { Id = 1, PurchaseId = 1, ProductId = id, Quantity = random.Next(1, 5), Product = GetProduct() },
                new PurchaseItem() { Id = 2, PurchaseId = 2, ProductId = id, Quantity = random.Next(1, 5), Product = GetProduct() },
            };

            product.PurchaseItems = purchaseItems;

            return product;
        }
    }
}
