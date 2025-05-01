
using NetStock.Entities;

namespace NetStock.Repositories
{

    public interface ICategory
    {
        Task<IEnumerable<Categories>> GetAllAsync();
        Task<Categories> GetByIdAsync(int id);
        Task AddAsync(Categories category);
        Task UpdateAsync(Categories category);
        Task DeleteAsync(int id);
    }
}
