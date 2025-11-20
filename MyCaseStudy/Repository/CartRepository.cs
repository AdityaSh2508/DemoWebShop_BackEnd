using Microsoft.EntityFrameworkCore;
using MyCaseStudy.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCaseStudy.Data;
using MyCaseStudy.Dto;
using MyCaseStudy.Interface;

namespace MyCaseStudy.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ShoppingContext _context;

        public CartRepository(ShoppingContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCartAsync(AddRemoveCartRequestDto request)
        {
            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.UserId == request.UserId && c.ProductId == request.ProductId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cartItem = new CartItem
                {
                    UserId = request.UserId,
                    ProductId = request.ProductId,
                    Quantity = 1
                };
                await _context.CartItems.AddAsync(cartItem);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveCartAsync(AddRemoveCartRequestDto request)
        {
            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.UserId == request.UserId && c.ProductId == request.ProductId);

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> UpdateCartAsync(UpdateCartRequestDto request)
        {
            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.UserId == request.UserId && c.ProductId == request.ProductId);

            if (cartItem == null)
                return false;

            if (request.IsIncrement)
                cartItem.Quantity++;
            else
                cartItem.Quantity = cartItem.Quantity > 1 ? cartItem.Quantity - 1 : 1;

            _context.CartItems.Update(cartItem);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<CartDto>> ViewCartAsync(int userId)
        {
            return await _context.CartItems
                .Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .Select(c => new CartDto
                {
                    CartItemId = c.CartItemId,
                    ProductName = c.Product.ProductName,
                    Quantity = c.Quantity,
                    PricePerItem = c.Product.Price,
                    ProductUrl = c.Product.ProductUrl
                })
                .ToListAsync();
        }
    }
}
