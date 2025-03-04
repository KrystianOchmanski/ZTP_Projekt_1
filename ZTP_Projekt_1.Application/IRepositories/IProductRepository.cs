using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Application.IRepositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id, bool includeCategory = true);

        Task<IEnumerable<Product>> GetAllAsync(bool includeCategories = true);

        Task<Product> AddAsync(Product product);

        Product Update(Product product);

        bool Remove(Product product);
    }
}
