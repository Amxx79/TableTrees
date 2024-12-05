using TableTree.Data.Models;

namespace TableTree.Web.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public Guid Id { get; set; }
		//public Guid ApplicationUserId { get; set; }
		public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Category Category { get; set; }
        public TreeType TreeType { get; set; }
        public IEnumerable<ProductStore> ProductStores { get; set; } = new HashSet<ProductStore>();
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    }
}
