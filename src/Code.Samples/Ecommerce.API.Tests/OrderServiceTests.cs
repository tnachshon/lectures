using System.Collections.Generic;
using Ecommerce.API.EF;
using Ecommerce.API.Models;
using Ecommerce.API.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ecommerce.API.Tests
{
	public class OrderServiceTests
	{
		[Fact]
		public void GetOrders_ShouldReturnListOfOrders()
		{
			// Arrange
			var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;

			using var dbContext = new AppDbContext(dbContextOptions);
			dbContext.Orders.Add(new Order { Id = 1, UserId = "user1" });
			dbContext.Orders.Add(new Order { Id = 2, UserId = "user2" });
			dbContext.SaveChanges();

			var orderService = new OrderService(dbContext);

			// Act
			var orders = orderService.GetOrders();

			// Assert
			Assert.NotNull(orders);
			Assert.Equal(2, orders.Count());
		}

	}
}