namespace TableTree.Web.ViewModels.Order
{
    public class OrderDetailsViewModel
    {
        public string Id { get; set; }
        public int SequenceNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<ProductViewModel> ProductsInOrder { get; set; }
    }
}
