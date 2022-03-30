using Microsoft.AspNetCore.Mvc;
using TriviumApiTest.Data;
using TriviumApiTest.Models;

namespace TriviumApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientsRepository _repository;

        public ClientsController(
            ILogger<ClientsController> logger,
            IClientsRepository repository
        )
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetClients")]
        public ActionResult<IEnumerable<Client>> Get()
        {
            var clients = _repository.GetClients();
            return new OkObjectResult(clients);
        }

        [HttpGet("{id}", Name = "GetClientById")]
        public ActionResult<Client> GetById(int id)
        {
            var client = _repository.GetClientById(id);

            if (client == null)
                return new NotFoundResult();

            return new OkObjectResult(client);
        }

        [HttpPost(Name = "CreateClient")]
        public IActionResult Create(Client client)
        {
            var successful = _repository.CreateClient(client);

            if (successful)
                return new OkResult();

            return new BadRequestResult();
        }

        [HttpPut(Name = "UpdateClient")]
        public IActionResult Update(Client client)
        {
            var successful = _repository.UpdateClient(client);

            if(successful)
                return new OkResult();

            return new BadRequestResult();
        }

        [HttpDelete(Name = "DeleteClient")]
        public IActionResult Delete(int id)
        {
            var successful = _repository.DeleteClient(id);

            if (successful)
                return new OkResult();

            return new BadRequestResult();
        }

        [HttpGet("{id}/purchases", Name = "GetPurchasesByClientId")]
        public ActionResult<IEnumerable<Purchase>> GetPurchases(int id)
        {
            var client = _repository.GetClientById(id);
            if (client == null)
                return new NotFoundResult();

            var purchases = _repository.GetPurchasesByClientId(id);
            return new OkObjectResult(purchases);
        }

        [HttpGet("{id}/purchases/top-products", Name = "GetTopProducts")]
        public ActionResult<IEnumerable<Purchase>> GetTop5(int id)
        {
            var client = _repository.GetClientById(id);
            if (client == null)
                return new NotFoundResult();

            var products = _repository.GetTopProductsBoughtByClient(id, 5);

            var mappedProducts = products.ToList().ConvertAll(x => new
            {
                x.Id,
                x.Name,
                x.Price
            });

            return new OkObjectResult(mappedProducts);
        }
    }
}
