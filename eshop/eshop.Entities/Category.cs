﻿namespace eshop.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Product> Products { get; set; }

    }
}
