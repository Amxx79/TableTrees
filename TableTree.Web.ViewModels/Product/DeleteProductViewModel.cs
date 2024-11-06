namespace TableTree.Web.ViewModels.Product
{
    public class DeleteProductViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string Category { get; set; }
        public string TreeType { get; set; }
    }
}
