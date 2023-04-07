using eshop.Entities;
using eshop.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace eshop.Infrastucture.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly EshopDbContext dbContext;

        public EFCategoryRepository(EshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Category entity)
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

        public IList<Category> GetAllItems()
        {
            return dbContext.Categories.ToList();
        }

        public async Task<IList<Category>> GetAllItemsAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public Category GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
