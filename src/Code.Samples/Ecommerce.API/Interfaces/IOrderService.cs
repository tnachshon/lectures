using Ecommerce.API.Models;

namespace Ecommerce.API.Interfaces
{
	public interface IOrderService
	{
		IEnumerable<Order> GetOrders();
		Order GetOrderById(int id);
		Order CreateOrder(Order order);
		bool UpdateOrder(int id, Order updatedOrder);
		bool DeleteOrder(int id);
	}

}
