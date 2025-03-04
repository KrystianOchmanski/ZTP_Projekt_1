using ZTP_Projekt_1.Application.IRepositories;
using ZTP_Projekt_1.Application.IServices;
using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> AddAsync(Category category)
        {
            if (await _categoryRepository.GetByNameAsync(category.Name) != null)
                throw new ArgumentException($"Category: {category.Name} already exist.");

            return await _categoryRepository.AddAsync(category);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _categoryRepository.GetByNameAsync(name);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new KeyNotFoundException($"Category ID:{id} was not found.");

            return await _categoryRepository.Remove(category);
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            if (await _categoryRepository.GetByNameAsync(category.Name) != null)
                throw new ArgumentException($"Category: {category.Name} already exist.");

            return await _categoryRepository.Update(category);
        }
    }
}
