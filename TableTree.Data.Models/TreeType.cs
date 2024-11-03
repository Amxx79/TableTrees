using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTree.Data.Models
{
    public class TreeType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; } = new HashSet<Product>();
    }
}
