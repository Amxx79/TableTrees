namespace TableTree.Data.Models
{
    public class ProductStore
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public bool IsDeleted { get; set; }
    }
}
