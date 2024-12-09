namespace TableTree.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; }
		public string FirstName { get; set; } //NEW
		public string LastName { get; set; } //NEW
		public string PhoneNumber { get; set; } //NEW
		public int SequenceNumber { get; set; }
		public string? ShippingCity { get; set; } //NEW
		public string? ShippingAddress { get; set; } //NEW
		public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<OrderItemInfo> Items { get; set; } = new List<OrderItemInfo>();
    }
}
