using eshop.Entities;
using eshop.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task AddAsync(Product entity)
        {
            await dbContext.Products.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var entity = dbContext.Products.FirstOrDefault(p => p.Id == id);
            dbContext.Products.Remove(entity);
            dbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            dbContext.Products.Remove(entity);
            await dbContext.SaveChangesAsync();

        }

        public IList<Product> GetAllItems()
        {
            return dbContext.Products.ToList();
        }

        public async Task<IList<Product>> GetAllItemsAsync()
        {
            return await dbContext.Products.Include(p => p.Category).ToListAsync();
        }

        public Product GetItemById(int id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Product> GetItemByIdAsync(int id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public IList<Product> GetProductsByCategoryId(int categoryId)
        {
            return dbContext.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public async Task<IList<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await dbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return dbContext.Products.Where(x => x.Name.Contains(name)).ToList();
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            return await dbContext.Products.Where(x => x.Name.Contains(name)).ToListAsync();

        }

        public async Task<bool> IsItemExistsAsync(int id)
        {
            return await dbContext.Products.AnyAsync(p => p.Id == id);
        }

        public void Update(Product entity)
        {
            dbContext.Products.Update(entity);
            //dbContext.Entry<Product>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();

        }

        public async Task UpdateAsync(Product entity)
        {
            dbContext.Products.Update(entity);
            await dbContext.SaveChangesAsync();

        }
    }
}
