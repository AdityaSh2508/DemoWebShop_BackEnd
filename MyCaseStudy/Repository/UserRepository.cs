using Microsoft.EntityFrameworkCore;
using MyCaseStudy.Data;
using MyCaseStudy.Dto;
using MyCaseStudy.Interface;
using MyCaseStudy.Models;

namespace MyCaseStudy.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ShoppingContext _context;

        public UserRepository(ShoppingContext context)
        {
            _context = context;
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> RegisterUserAsync(UserRegisterDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                Mobile = userDto.Mobile
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<UserResponseDto> LoginUserAsync(UserLoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

            if (user == null)
                return null;

            return new UserResponseDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Mobile = user.Mobile
            };
        }
    }
}
