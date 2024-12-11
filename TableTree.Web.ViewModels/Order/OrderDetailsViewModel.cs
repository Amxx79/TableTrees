namespace TableTree.Web.ViewModels.Order
{
    public class OrderDetailsViewModel
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string DeliveryMethod { get; set; } = null!;
        public string ShippingCity { get; set; } = null!;
        public string ShippingAddress { get; set; } = null!;
        public int SequenceNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<ProductViewModel> ProductsInOrder { get; set; }
    }
}
