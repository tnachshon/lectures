using Ecommerce.API.EF;
using Ecommerce.API.Models;

namespace Ecommerce.API.Services
{
	public class PaymentService
	{
		private readonly AppDbContext _dbContext;

		public PaymentService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<Payment> GetPayments()
		{
			return _dbContext.Payments.ToList();
		}

		public Payment GetPaymentById(int id)
		{
			return _dbContext.Payments.FirstOrDefault(p => p.Id == id);
		}

		public Payment CreatePayment(Payment payment)
		{
			_dbContext.Payments.Add(payment);
			_dbContext.SaveChanges();
			return payment;
		}

		public void UpdatePayment(int id, Payment updatedPayment)
		{
			var existingPayment = _dbContext.Payments.FirstOrDefault(p => p.Id == id);
			if (existingPayment != null)
			{
				existingPayment.OrderId = updatedPayment.OrderId;
				existingPayment.Amount = updatedPayment.Amount;
				existingPayment.PaymentDate = updatedPayment.PaymentDate;
				existingPayment.PaymentMethod = updatedPayment.PaymentMethod;
				// Update other properties as needed
				_dbContext.SaveChanges();
			}
		}

		public void DeletePayment(int id)
		{
			var payment = _dbContext.Payments.FirstOrDefault(p => p.Id == id);
			if (payment != null)
			{
				_dbContext.Payments.Remove(payment);
				_dbContext.SaveChanges();
			}
		}
	}

}
