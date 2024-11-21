namespace TableTree.Web.ViewModels.Order
{
    public class OrderViewModel
    {
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public int SequenceNumber { get; set; }
        public string OrderDate { get; set; }
        public string TotalPrice { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}
