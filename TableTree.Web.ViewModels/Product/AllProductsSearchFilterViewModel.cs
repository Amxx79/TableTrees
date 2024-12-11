using TableTree.Data.Models;

namespace TableTree.Web.ViewModels.Product
{
    public class AllProductsSearchFilterViewModel
    {
        public IEnumerable<ProductViewModel>? Products { get; set; } = new List<ProductViewModel>();
        public string? TypeOfTree { get; set; }
        public string? Category { get; set; }
        public IEnumerable<TreeType> AllTypeOfTrees { get; set; } = new List<TreeType>();
        public IEnumerable<Category> AllCategories { get; set; } = new List<Category>();
    }
}
