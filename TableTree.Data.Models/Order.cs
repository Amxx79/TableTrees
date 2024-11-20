namespace TableTree.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int SequenceNumber { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<Product> Items { get; set; } = new List<Product>();
    }
}
