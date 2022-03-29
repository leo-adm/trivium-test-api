using Microsoft.AspNetCore.Mvc;
using TriviumApiTest.Data;
using TriviumApiTest.Models;

namespace TriviumApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchasesController
    {
        private readonly ILogger<PurchasesController> _logger;
        private readonly IPurchasesRepository _repository;

        public PurchasesController(
            ILogger<PurchasesController> logger,
            IPurchasesRepository repository
        )
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetPurchases")]
        public ActionResult<IEnumerable<Purchase>> Get()
        {
            var purchases = _repository.GetPurchases();
            return new OkObjectResult(purchases);
        }
    }
}
