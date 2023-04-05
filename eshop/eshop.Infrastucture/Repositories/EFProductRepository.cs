using eshop.Entities;
using eshop.Infrastucture.Data;

namespace eshop.Infrastucture.Repositories
{
    public class EFProductRepository : IProductRepository
    {

        private readonly EshopDbContext dbContext;

        public EFProductRepository(EshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Product entity)
        {
            dbContext.Products.Add(entity);
            dbContext.SaveChanges();
        }

        public Task AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAllItems()
        {
            return dbContext.Products.ToList();
        }

        public Task<IList<Product>> GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Product GetItemById(int id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public Task<Product> GetItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProductsByCategoryId(int categoryId)
        {
            return dbContext.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public Task<IList<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByNameAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            dbContext.Products.Update(entity);
            //dbContext.Entry<Product>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();

        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
