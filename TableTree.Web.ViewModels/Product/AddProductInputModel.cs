namespace TableTree.Web.ViewModels.Product
{
    public class AddProductInputModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
        public Guid TreeType { get; set; }
        public Guid Category { get; set; }
    }
}
