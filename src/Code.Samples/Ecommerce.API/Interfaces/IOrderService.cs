using Ecommerce.API.Models;

namespace Ecommerce.API.Interfaces
{
	public interface IOrderService
	{
		IEnumerable<Order> GetOrders();
		Order GetOrderById(int id);
		Order CreateOrder(Order order);
		void UpdateOrder(int id, Order updatedOrder);
		void DeleteOrder(int id);
	}

}
