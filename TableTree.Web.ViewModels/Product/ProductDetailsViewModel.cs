using TableTree.Data.Models;

namespace TableTree.Web.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Category Category { get; set; }
        public TreeType TreeType { get; set; }
    }
}
