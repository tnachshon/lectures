using Ecommerce.API.EF;
using Ecommerce.API.Models;

namespace Ecommerce.API.Services
{
	public class OrderService
	{
		private readonly AppDbContext _dbContext;

		public OrderService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<Order> GetOrders()
		{
			return _dbContext.Orders.ToList();
		}

		public Order GetOrderById(int id)
		{
			return _dbContext.Orders.FirstOrDefault(o => o.Id == id);
		}

		public Order CreateOrder(Order order)
		{
			_dbContext.Orders.Add(order);
			_dbContext.SaveChanges();
			return order;
		}

		public void UpdateOrder(int id, Order updatedOrder)
		{
			var existingOrder = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
			if (existingOrder != null)
			{
				existingOrder.UserId = updatedOrder.UserId;
				// Update other properties as needed
				_dbContext.SaveChanges();
			}
		}

		public void DeleteOrder(int id)
		{
			var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
			if (order != null)
			{
				_dbContext.Orders.Remove(order);
				_dbContext.SaveChanges();
			}
		}
	}

}
