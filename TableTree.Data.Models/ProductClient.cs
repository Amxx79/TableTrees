using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTree.Data.Models
{
    public class ProductClient
    {
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
