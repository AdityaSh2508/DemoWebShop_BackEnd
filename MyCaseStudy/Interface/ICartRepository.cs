using MyCaseStudy.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCaseStudy.Interface
{
    public interface ICartRepository
    {
        Task<bool> AddCartAsync(AddRemoveCartRequestDto request);
        Task<bool> UpdateCartAsync(UpdateCartRequestDto request);
        Task<bool> RemoveCartAsync(AddRemoveCartRequestDto request);
        Task<List<CartDto>> ViewCartAsync(int userId);
    }
}
