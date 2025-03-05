using ZTP_Projekt_1.Application.IRepositories;
using ZTP_Projekt_1.Application.IServices;
using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBlockedNameRepository _blockedNameRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IBlockedNameRepository blockedNameRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _blockedNameRepository = blockedNameRepository;
        }

        public async Task<Product> AddAsync(Product product)
        {
            if(await _blockedNameRepository.FindByNameAsync(product.Name) != null)
                throw new ArgumentException($"Name {product.Name} is blocked.");

            if (await _productRepository.IsNameUsed(product.Name))
                throw new ArgumentException($"Product with name {product.Name} already exist.");            

            var category = await _categoryRepository.GetByIdAsync(product.CategoryId)
                ?? throw new ArgumentException("Category was not found");
            
            category.ValidatePrice(product.Price);

            product.Category = category;

            return await _productRepository.AddAsync(product);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if(product  == null)
            {
                throw new ArgumentException("Product not found.");
            }

            return await _productRepository.Remove(product);
        }

        public async Task<Product> UpdateAsync(Product editProduct)
        {
            var product = await _productRepository.GetByIdAsync(editProduct.Id)
                ?? throw new ArgumentException("Product not found");

            if (await _blockedNameRepository.FindByNameAsync(editProduct.Name) != null)
                throw new ArgumentException($"Name: {editProduct.Name} is blocked.");

            product.Category.ValidatePrice(editProduct.Price);

            product.Update(editProduct);

            return await _productRepository.Update(product);
        }
    }
}
