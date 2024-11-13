﻿namespace TableTree.Data.Models
{
    public class ProductClient
    {
        public int QuantityOfProducts { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
