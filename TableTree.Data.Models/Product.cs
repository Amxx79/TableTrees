using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTree.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ImageUrl { get; set; }
        public bool IsDeleted { get; set; }

        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public Guid TreeTypeId { get; set; }
        public virtual TreeType TreeType { get; set; } = null!;

        //TODO: List of ProductClients
    }
}
