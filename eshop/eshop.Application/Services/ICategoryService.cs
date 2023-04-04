using eshop.Entities;

namespace eshop.Application.Services
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetCategories();
        public Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
