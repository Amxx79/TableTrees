using System.ComponentModel.DataAnnotations;
using TableTree.Data.Models;

namespace TableTree.Web.ViewModels.Product
{
    public class AddProductInputModel
    {
        //Fix this validations
        [Required]
        [MinLength(5, ErrorMessage ="Minimum length is 5")]
        public string Name { get; set; }
        [MinLength(10, ErrorMessage = "Minimum length is 10")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid TreeType { get; set; }
        public Guid Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<TreeType> TreeTypes { get; set; }
    }
}
