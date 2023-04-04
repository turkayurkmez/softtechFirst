using eshop.Entities;

namespace eshop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        public IEnumerable<Category> GetCategories()
        {
            return new List<Category>()
           {
               new(){ Id=1, Name="Mutfak aletleri"},
               new(){ Id=2, Name="Bilgisayar"},

           };
        }

        public Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
