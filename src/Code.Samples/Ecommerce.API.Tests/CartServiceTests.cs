using System.Collections.Generic;
using Ecommerce.API.EF;
using Ecommerce.API.Models;
using Ecommerce.API.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ecommerce.API.Tests
{
	public class CartServiceTests
	{
		[Fact]
		public void GetCarts_ShouldReturnListOfCarts()
		{
			// Arrange
			var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;

			using var dbContext = new AppDbContext(dbContextOptions);
			dbContext.Carts.Add(new Cart { Id = 1, UserId = "user1" });
			dbContext.Carts.Add(new Cart { Id = 2, UserId = "user2" });
			dbContext.SaveChanges();

			var cartService = new CartService(dbContext);

			// Act
			var carts = cartService.GetCarts();

			// Assert
			Assert.NotNull(carts);
			Assert.Equal(2, carts.Count());
		}

	}
}