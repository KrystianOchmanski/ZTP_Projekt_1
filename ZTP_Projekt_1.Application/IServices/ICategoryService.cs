using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Application.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(int id);

        Task<Category?> GetByNameAsync(string name);

        Task<Category> AddAsync(Category category);

        Task<Category> UpdateAsync(Category category);

        Task<bool> RemoveAsync(int id);
    }
}
