using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Application.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(int id);

        Task<Category?> GetByNameAsync(string name);

        Task<Category> AddAsync(Category category);

        Category Update(Category category);

        bool Remove(Category category);
    }
}
