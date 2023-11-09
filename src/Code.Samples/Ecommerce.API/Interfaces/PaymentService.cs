using Ecommerce.API.Models;

namespace Ecommerce.API.Interfaces
{
	public interface IPaymentService
	{
		IEnumerable<Payment> GetPayments();
		Payment GetPaymentById(int id);
		Payment CreatePayment(Payment payment);
		void UpdatePayment(int id, Payment updatedPayment);
		void DeletePayment(int id);
	}

}
