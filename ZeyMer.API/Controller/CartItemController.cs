using Microsoft.AspNetCore.Mvc;
using ZeyMer.Application.Interfaces;
using ZeyMer.Domain.Entities;

namespace ZeyMer.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cartItems = await _cartItemService.GetAllAsync();
            return Ok(cartItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cartItem = await _cartItemService.GetByIdAsync(id);
            if (cartItem == null)
                return NotFound();

            return Ok(cartItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CartItem cartItem)
        {
            var createdCartItem = await _cartItemService.AddAsync(cartItem);
            return CreatedAtAction(nameof(GetById), new { id = createdCartItem.Id }, createdCartItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CartItem cartItem)
        {
            if (id != cartItem.Id)
                return BadRequest();

            await _cartItemService.UpdateAsync(cartItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _cartItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
