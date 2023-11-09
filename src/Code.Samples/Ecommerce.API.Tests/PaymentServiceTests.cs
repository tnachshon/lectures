using System.Collections.Generic;
using Ecommerce.API.EF;
using Ecommerce.API.Models;
using Ecommerce.API.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ecommerce.API.Tests
{
	public class PaymentServiceTests
	{
		[Fact]
		public void GetPayments_ShouldReturnListOfPayments()
		{
			// Arrange
			var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;

			using var dbContext = new AppDbContext(dbContextOptions);
			dbContext.Payments.Add(new Payment { Id = 1, OrderId = 1, Amount = 100, PaymentDate = DateTime.Now, PaymentMethod = "CC" });
			dbContext.Payments.Add(new Payment { Id = 2, OrderId = 2, Amount = 150, PaymentDate = DateTime.Now.AddDays(-3), PaymentMethod = "GPAY" });
			dbContext.SaveChanges();

			var paymentService = new PaymentService(dbContext);

			// Act
			var payments = paymentService.GetPayments();

			// Assert
			Assert.NotNull(payments);
			Assert.Equal(2, payments.Count());

			var gpayPayments = paymentService.GetPayment(payment => payment.PaymentMethod == "GPAY");

			Assert.NotNull(gpayPayments);
			Assert.Equal(1, gpayPayments.Count());

		}

	}
}