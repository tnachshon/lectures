using Ecommerce.API.EF;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;

namespace Ecommerce.API.Services
{
	public class OrderService : IOrderService
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

		public bool UpdateOrder(int id, Order updatedOrder)
		{
			var existingOrder = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
			if (existingOrder != null)
			{
				existingOrder.UserId = updatedOrder.UserId;
				// Update other properties as needed
				var changed = _dbContext.SaveChanges();
				return changed > 0;
			}
			return false;
		}

		public bool DeleteOrder(int id)
		{
			var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
			if (order != null)
			{
				_dbContext.Orders.Remove(order);
				var changed =_dbContext.SaveChanges();
				return changed > 0;
			}
			return false;
		}
	}

}
