using TableTree.Data.Models;

namespace TableTree.Web.ViewModels.Cart
{
    public class AddProductInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid TreeType { get; set; }
        public Guid Category { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<TreeType>? TreeTypes { get; set; }
    }
}
