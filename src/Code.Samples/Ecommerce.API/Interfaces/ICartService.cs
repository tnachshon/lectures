using Ecommerce.API.Models;

namespace Ecommerce.API.Interfaces
{
	public interface ICartService
	{
		IEnumerable<Cart> GetCarts();
		Cart GetCartById(int id);
		Cart CreateCart(Cart cart);
		bool UpdateCart(int id, Cart updatedCart);
		bool DeleteCart(int id);
	}

}
