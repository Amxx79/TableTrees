﻿namespace TableTree.Web.ViewModels.Favourite
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string TreeType { get; set; }
    }
}
