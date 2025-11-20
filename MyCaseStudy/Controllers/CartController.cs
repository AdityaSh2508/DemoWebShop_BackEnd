using Microsoft.AspNetCore.Mvc;
using MyCaseStudy.Dto;
using MyCaseStudy.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepo;

        public CartController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCart([FromBody] AddRemoveCartRequestDto request)
        {
            var result = await _cartRepo.AddCartAsync(request);
            if (!result)
                return BadRequest("Failed to add item to cart");

            return Ok("Item added to cart");
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveCart([FromBody] AddRemoveCartRequestDto request)
        {
            var result = await _cartRepo.RemoveCartAsync(request);
            if (!result)
                return NotFound("Item not found in cart");

            return Ok("Item removed from cart");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCart([FromBody] UpdateCartRequestDto request)
        {
            var result = await _cartRepo.UpdateCartAsync(request);
            if (!result)
                return NotFound("Item not found in cart");

            return Ok("Cart updated");
        }

        [HttpGet("view/{userId}")]
        public async Task<ActionResult<List<CartDto>>> ViewCart(int userId)
        {
            var cartItems = await _cartRepo.ViewCartAsync(userId);
            return Ok(cartItems);
        }
    }
}





// GET: api/cart/view?userId=1
//[HttpGet("view")]
//public async Task<IActionResult> ViewCart(int userId)
//{
//    var cart = await _cartRepository.ViewCartAsync(userId);
//    if (cart == null)
//        return NotFound("User not found or cart is empty.");

//    return Ok(cart);
//}