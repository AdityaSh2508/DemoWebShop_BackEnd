using MyCaseStudy.Dto;
using MyCaseStudy.Models;

namespace MyCaseStudy.Interface
{
    public interface IUserRepository
    {
        Task<bool> IsEmailExistsAsync(string email);
        Task<bool> RegisterUserAsync(UserRegisterDto userDto);
        Task<UserResponseDto> LoginUserAsync(UserLoginDto loginDto);
    }
}
