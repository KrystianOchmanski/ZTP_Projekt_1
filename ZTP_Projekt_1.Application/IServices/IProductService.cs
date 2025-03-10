using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Application.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync(bool includeCategories = true);

        Task<Product?> GetByIdAsync(int id);

        Task<Product> AddAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<bool> RemoveAsync(int id);
    }
}
