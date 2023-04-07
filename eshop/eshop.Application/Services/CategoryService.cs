using eshop.Entities;
using eshop.Infrastucture.Repositories;

namespace eshop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetAllItems();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await categoryRepository.GetAllItemsAsync();
        }
    }
}
