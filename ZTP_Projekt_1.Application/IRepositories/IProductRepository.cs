using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Application.IRepositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);

        Task<Product> AddAsync(Product product);

        Product Update(Product product);

        void Remove(Product product);
    }
}
