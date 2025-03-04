using Microsoft.EntityFrameworkCore;
using ZTP_Projekt_1.Application.IRepositories;
using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> AddAsync(Category category)
        {
            var entry = await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync(); 
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<bool> Remove(Category category)
        {
            var entry = _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            if(entry.State == EntityState.Detached)
                return true;
            return false;
        }

        public async Task<Category> Update(Category category)
        {
            var entry = _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
