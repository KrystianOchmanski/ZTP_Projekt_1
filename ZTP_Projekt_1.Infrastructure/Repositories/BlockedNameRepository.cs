using Microsoft.EntityFrameworkCore;
using ZTP_Projekt_1.Application.IRepositories;
using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Infrastructure.Repositories
{
    public class BlockedNameRepository : IBlockedNameRepository
    {
        private readonly AppDbContext _context;

        public BlockedNameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BlockedName> AddAsync(BlockedName blockedName)
        {
            var entry = await _context.BlockedNames.AddAsync(blockedName);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<BlockedName?> FindByNameAsync(string name)
        {
            return await _context.BlockedNames.FirstOrDefaultAsync(b => b.Name == name);
        }

        public async Task<IEnumerable<BlockedName>> GetBlockedNamesAsync()
        {
            return await _context.BlockedNames.ToListAsync();
        }

        public async Task<bool> Remove(BlockedName blockedName)
        {
            var entry = _context.BlockedNames.Remove(blockedName);
            await _context.SaveChangesAsync();

            if(entry.State == EntityState.Deleted)
                return true;
            return false;
        }
    }
}
