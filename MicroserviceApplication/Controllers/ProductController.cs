using MicroserviceApplication.Models;
using MicroserviceApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceApplication.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var products = _productRepository.GetProducts();
            return new OkObjectResult(products);
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            var product = _productRepository.GetProductById(id);
            return new OkObjectResult(product);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            _productRepository.AddProduct(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);

        }

        [HttpPut]
        public ActionResult Put([FromBody] Product product)
        {
            if(product != null)
            {
                _productRepository.UpdateProduct(product);
                return new OkResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return new OkResult();
        }
    }
}
