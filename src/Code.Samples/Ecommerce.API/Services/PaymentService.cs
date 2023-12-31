﻿using Ecommerce.API.EF;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;

namespace Ecommerce.API.Services
{
	public class PaymentService : IPaymentService
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

		public IEnumerable<Payment> GetPayment(Func<Payment, bool> predicate)
		{
			return _dbContext.Payments.Where(predicate).ToList();
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

		public bool UpdatePayment(int id, Payment updatedPayment)
		{
			var existingPayment = _dbContext.Payments.FirstOrDefault(p => p.Id == id);
			if (existingPayment != null)
			{
				existingPayment.OrderId = updatedPayment.OrderId;
				existingPayment.Amount = updatedPayment.Amount;
				existingPayment.PaymentDate = updatedPayment.PaymentDate;
				existingPayment.PaymentMethod = updatedPayment.PaymentMethod;
				// Update other properties as needed
				var changed = _dbContext.SaveChanges();
				return changed > 0;
			}
			return false;
		}

		public bool DeletePayment(int id)
		{
			var payment = _dbContext.Payments.FirstOrDefault(p => p.Id == id);
			if (payment != null)
			{
				_dbContext.Payments.Remove(payment);
				var changed = _dbContext.SaveChanges();
				return changed > 0;
			}
			return false;
		}
	}

}
