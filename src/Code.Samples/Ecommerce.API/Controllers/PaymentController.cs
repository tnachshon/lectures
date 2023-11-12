using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
	[Route("api/payments")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly IPaymentService _paymentService;
		public PaymentController(IPaymentService paymentService)
		{
			_paymentService = paymentService;
		}
		// GET: api/payments
		[HttpGet]
		public IActionResult GetPayments()
		{
			var payments = _paymentService.GetPayments();
			return Ok(payments);
		}

		// GET: api/payments/{id}
		[HttpGet("{id}")]
		public IActionResult GetPayment(int id)
		{
			var payment = _paymentService.GetPaymentById(id);
			return Ok(payment);
		}

		// POST: api/payments
		[HttpPost]
		public IActionResult CreatePayment([FromBody] Payment payment)
		{
			var dbPayment = _paymentService.CreatePayment(payment);
			return Ok(dbPayment);
		}

		// PUT: api/payments/{id}
		[HttpPut("{id}")]
		public IActionResult UpdatePayment(int id, [FromBody] Payment payment)
		{
			_paymentService.UpdatePayment(id, payment);
			return Ok();
		}

		// DELETE: api/payments/{id}
		[HttpDelete("{id}")]
		public IActionResult DeletePayment(int id)
		{
			_paymentService.DeletePayment(id);
			return Ok();
		}
	}

}
