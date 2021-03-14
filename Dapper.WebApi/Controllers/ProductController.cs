using Dapper.WebApi.Models;
using Dapper.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        /*
        [HttpGet]
        public async Task<ActionResult<Product>> GellAll()
        {
            var products = await _productRepository.GetAllProducts();
            return Ok(products);
        }
        */
        [HttpPost]
        [Route("/sta")]//sta = saving the application
        public async Task<ActionResult> AddProduct(Product entity)
        {
            await _productRepository.AddProduct(entity);
            return Ok(entity.Request_id);
        }

        [HttpPost]
        [Route("/roa/request_id")]//roa =receipt of application
        public async Task<ActionResult> GetById(Product entity)
        {
            await _productRepository.GetById(entity);
            object[] resultset = new object[3] { entity.Amount, entity.Currency, entity.Status };
            return Ok(resultset);
        }

        [HttpPost] 
        [Route("/roa/client_id_department_address")]//roa =receipt of application var 2
        public async Task<ActionResult<Product>> GetByIdAddress(Product entity)
        {
            var products = await _productRepository.GetByIdAddress(entity);
            return Ok(products);
        }
    }
}