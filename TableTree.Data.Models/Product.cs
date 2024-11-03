using System.ComponentModel.DataAnnotations;
using static TableTree.Common.EntityValidationContants.Product;


namespace TableTree.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        [Required]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionMinLength)]
        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public Guid TreeTypeId { get; set; }
        public virtual TreeType TreeType { get; set; } = null!;
        public IEnumerable<ProductClient> ProductsClients { get; set; } = new HashSet<ProductClient>();
    }
}
