using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
	[Route("api/carts")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly ICartService _cartService;
		public CartController(ICartService cartService)
		{
			_cartService = cartService;
		}

		// GET: api/carts
		[HttpGet]
		public IActionResult GetCarts()
		{
			var carts = _cartService.GetCarts();
			return Ok(carts);
		}

		// GET: api/carts/{id}
		[HttpGet("{id}")]
		public IActionResult GetCart(int id)
		{
			var cart = _cartService.GetCartById(id);	
			return Ok(cart);	
		}

		// POST: api/carts
		[HttpPost]
		public IActionResult CreateCart([FromBody] Cart cart)
		{
			var dbCart = _cartService.CreateCart(cart);
			return Ok(dbCart);
		}

		// PUT: api/carts/{id}
		[HttpPut("{id}")]
		public IActionResult UpdateCart(int id, [FromBody] Cart cart)
		{
			_cartService.UpdateCart(id, cart);
			return Ok();	
		}

		// DELETE: api/carts/{id}
		[HttpDelete("{id}")]
		public IActionResult DeleteCart(int id)
		{
			_cartService.DeleteCart(id);
			return Ok();
		}
	}

}
