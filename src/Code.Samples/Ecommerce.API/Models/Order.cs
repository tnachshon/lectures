namespace Ecommerce.API.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string UserId { get; set; } // Add relevant user identifier
		public List<OrderItem> Items { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal TotalAmount { get; set; }
	}

	public class OrderItem
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
	}

}
