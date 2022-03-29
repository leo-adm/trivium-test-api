using Microsoft.AspNetCore.Mvc;
using TriviumApiTest.Data;
using TriviumApiTest.Models;

namespace TriviumApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsRepository _repository;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductsRepository repository
        )
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetProducts")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _repository.GetProducts();
            return new OkObjectResult(products);
        }

        [HttpGet("purchases", Name = "GetProductsWithPurchasesInfo")]
        public ActionResult<IEnumerable<Product>> GetProductsWithPurchasesInfo()
        {
            var products = _repository.GetProductsWithPurchasesInfo();

            var mappedProducts = products.ToList().ConvertAll(product => new
            {
                product.Id,
                product.Name,
                product.Price,
                product.TotalRaised,
                product.TotalPurchasesIncluded,
            });

            return new OkObjectResult(mappedProducts);
        }

        [HttpGet("{id}/purchases", Name = "GetTotalPurchasesForProduct")]
        public ActionResult<Product> GetProductWithPurchasesInfo(int id)
        {
            var product = _repository.GetProductWithPurchasesInfo(id);

            var mappedProduct = new
            {
                product.Id,
                product.Name,
                product.Price,
                product.TotalRaised,
                product.TotalPurchasesIncluded,
            };

            return new OkObjectResult(mappedProduct);
        }
    }
}
