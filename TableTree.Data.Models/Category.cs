using System.ComponentModel.DataAnnotations;
using static TableTree.Common.EntityValidationContants.Category;

namespace TableTree.Data.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        [Required]
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; } = new HashSet<Product>();
    }
}
