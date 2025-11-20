using Microsoft.EntityFrameworkCore;
using MyCaseStudy.Data;
using MyCaseStudy.Dto;
using MyCaseStudy.Interface;

namespace MyCaseStudy.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingContext _context;

        public ProductRepository(ShoppingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> ProductListAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    CategoryName = p.Category.CategoryName,
                    Price = p.Price,
                    AvailableQuantity = p.AvailableQuantity,
                    ProductUrl = p.ProductUrl
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDto>> ProductSearchAsync(string query)
        {
            query = query.ToLower();

            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.ProductName.ToLower().Contains(query) ||
                            p.Category.CategoryName.ToLower().Contains(query))
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    CategoryName = p.Category.CategoryName,
                    Price = p.Price,
                    AvailableQuantity = p.AvailableQuantity,
                    ProductUrl = p.ProductUrl
                })
                .ToListAsync();
        }

        public async Task<ProductDto> ProductDetailAsync(int productId)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.ProductId == productId)
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    CategoryName = p.Category.CategoryName,
                    Price = p.Price,
                    AvailableQuantity = p.AvailableQuantity,
                    ProductUrl = p.ProductUrl
                })
                .FirstOrDefaultAsync();

            return product;
        }
    }
}
