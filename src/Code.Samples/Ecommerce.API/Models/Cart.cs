namespace Ecommerce.API.Models
{
	public class Cart
	{
		public int Id { get; set; }
		public string UserId { get; set; } // Add relevant user identifier
		public virtual List<CartItem> Items { get; set; }
	}

	public class CartItem
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
	}

}
