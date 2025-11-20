using Microsoft.AspNetCore.Mvc;
using MyCaseStudy.Interface;
using System.Threading.Tasks;

namespace MyCaseStudy.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/product
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productRepository.ProductListAsync();
                return Ok(products);
            }
            catch
            {
                return StatusCode(500, "Failed to fetch products.");
            }
        }

        // GET: api/product/search?query=phone
        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string query)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query))
                    return BadRequest("Search query is required.");

                var products = await _productRepository.ProductSearchAsync(query);
                return Ok(products);
            }
            catch
            {
                return StatusCode(500, "Search failed.");
            }
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetail(int id)
        {
            try
            {
                var product = await _productRepository.ProductDetailAsync(id);
                if (product == null)
                    return NotFound("Product not found.");

                return Ok(product);
            }
            catch
            {
                return StatusCode(500, "Failed to fetch product detail.");
            }
        }
    }
}
