using Ecommerce.API.EF;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.API.Services
{
	public class CartService : ICartService
	{
		private readonly AppDbContext _dbContext;

		public CartService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<Cart> GetCarts()
		{
			return _dbContext.Carts.Include(x => x.Items).ToList();
		}

		public Cart GetCartById(int id)
		{
			return _dbContext.Carts.FirstOrDefault(c => c.Id == id);
		}

		public Cart CreateCart(Cart cart)
		{
			_dbContext.Carts.Add(cart);
			_dbContext.SaveChanges();
			return cart;
		}

		public bool UpdateCart(int id, Cart updatedCart)
		{
			var existingCart = _dbContext.Carts.FirstOrDefault(c => c.Id == id);
			if (existingCart != null)
			{
				existingCart.UserId = updatedCart.UserId;
				// Update other properties as needed
				var changed = _dbContext.SaveChanges();
				return changed > 0;
			}
			return false;
		}

		public bool DeleteCart(int id)
		{
			var cart = _dbContext.Carts.FirstOrDefault(c => c.Id == id);
			if (cart != null)
			{
				_dbContext.Carts.Remove(cart);
				var changed = _dbContext.SaveChanges();
				return changed > 0;
			}
			return false;
		}
	}

}
