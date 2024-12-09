namespace TableTree.Web.ViewModels.Order
{
    public class OrderDetailsViewModel
    {
        public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string ShippingCity { get; set; }
		public string ShippingAddress { get; set; }
		public int SequenceNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<ProductViewModel> ProductsInOrder { get; set; }
    }
}
