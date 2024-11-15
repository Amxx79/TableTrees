namespace TableTree.Data.Models
{
    public class Store
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public IEnumerable<ProductStore> StoreProducts { get; set; } = new HashSet<ProductStore>();
    }
}
