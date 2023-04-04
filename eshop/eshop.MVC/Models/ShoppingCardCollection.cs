using eshop.Entities;

namespace eshop.MVC.Models
{
    public class ShoppingCardCollection
    {
        public List<ProductItem> Products { get; set; } = new List<ProductItem>();

        public void Clear() => Products.Clear();
        public double GetTotalPrice() => Products.Sum(p => p.Quantity * p.Product.Price.Value);

        public int GetTotalProductsCount() => Products.Sum(x => x.Quantity);

        public void AddProduct(ProductItem product)
        {

            var existingProduct = Products.FirstOrDefault(p => p.Product.Id == product.Product.Id);
            if (existingProduct == null)
            {
                Products.Add(product);
            }
            else
            {
                existingProduct.Quantity += product.Quantity;
            }
        }

    }

    public class ProductItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
