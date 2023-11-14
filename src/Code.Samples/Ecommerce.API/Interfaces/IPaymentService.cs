using Ecommerce.API.Models;

namespace Ecommerce.API.Interfaces
{
	public interface IPaymentService
	{
		IEnumerable<Payment> GetPayments();
		Payment GetPaymentById(int id);
		Payment CreatePayment(Payment payment);
		bool UpdatePayment(int id, Payment updatedPayment);
		bool DeletePayment(int id);
	}

}
