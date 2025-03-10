using Microsoft.EntityFrameworkCore;
using ZTP_Projekt_1.Application.IRepositories;
using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product product)
        {
            var entry = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync(); // Saving to generate entry ID

            var history = new ProductHistory(entry.Entity, "INSERT");
            await _context.ProductHistory.AddAsync(history);

            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(bool includeCategories = true)
        {
            return await PrepareQuery(includeCategories).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id, bool includeCategory = true)
        {
            return await PrepareQuery(includeCategory).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Remove(Product product)
        {
            var entry = _context.Remove(product);

            var history = new ProductHistory(product, "DELETE");
            await _context.ProductHistory.AddAsync(history);

            await _context.SaveChangesAsync();

            if (entry.State == EntityState.Detached)
                return true;
            return false;
        }

        public async Task<Product> Update(Product product)
        {
            var entry = _context.Products.Update(product);

            var history = new ProductHistory(product, "UPDATE");
            await _context.ProductHistory.AddAsync(history);

            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public IQueryable<Product> PrepareQuery(bool includeCategories) 
        { 
            var query = _context.Products.AsQueryable();
            if (includeCategories)
                query = query.Include(p => p.Category);
            return query;
        }

		public async Task<bool> IsNameUsed(string name)
		{
			return await _context.Products.AnyAsync(p => p.Name == name);
		}
	}
}
