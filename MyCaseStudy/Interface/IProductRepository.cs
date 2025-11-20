using MyCaseStudy.Dto;

namespace MyCaseStudy.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> ProductListAsync();
        Task<IEnumerable<ProductDto>> ProductSearchAsync(string query);
        Task<ProductDto> ProductDetailAsync(int productId);
    }
}