using eshop.Entities;

namespace eshop.Infrastucture.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        Task AddAsync(T entity);

        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(int id);
        Task DeleteAsync(int id);
        IList<T> GetAllItems();
        Task<IList<T>> GetAllItemsAsync();

        T GetItemById(int id);
        Task<T> GetItemByIdAsync(int id);
    }
}
