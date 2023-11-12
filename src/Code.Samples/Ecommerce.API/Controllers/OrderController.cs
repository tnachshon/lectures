using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
	[Route("api/orders")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;
		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}
		// GET: api/orders
		[HttpGet]
		public IActionResult GetOrders()
		{
			var orders = _orderService.GetOrders();
			return Ok(orders);
		}

		// GET: api/orders/{id}
		[HttpGet("{id}")]
		public IActionResult GetOrder(int id)
		{
			var order = _orderService.GetOrderById(id);
			return Ok(order);	
		}

		// POST: api/orders
		[HttpPost]
		public IActionResult CreateOrder([FromBody] Order order)
		{
			var dbOrder = _orderService.CreateOrder(order);
			return Ok(dbOrder);
		}

		// PUT: api/orders/{id}
		[HttpPut("{id}")]
		public IActionResult UpdateOrder(int id, [FromBody] Order order)
		{
			_orderService.UpdateOrder(id, order);
			return Ok();
		}

		// DELETE: api/orders/{id}
		[HttpDelete("{id}")]
		public IActionResult DeleteOrder(int id)
		{
			_orderService.DeleteOrder(id);
			return Ok();
		}
	}

}
