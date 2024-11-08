using System.ComponentModel.DataAnnotations;
using TableTree.Data.Models;
using static TableTree.Common.EntityValidationContants.Product;


namespace TableTree.Web.ViewModels.Product
{
    public class EditProductViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(NameMinLength, ErrorMessage = "Minimum length is {1}.")]
        [MaxLength(NameMaxLength, ErrorMessage = "Maximum length is {1}.")]
        public string Name { get; set; }
        [MinLength(DescriptionMinLength, ErrorMessage = "Minimum length is {1}")]
        [MaxLength(DescriptionMaxLength, ErrorMessage = "Minimum length is {1}")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid TreeType { get; set; }
        public Guid Category { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<TreeType>? TreeTypes { get; set; }
    }
}
