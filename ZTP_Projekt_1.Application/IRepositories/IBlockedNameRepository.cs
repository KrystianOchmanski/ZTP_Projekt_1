using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Application.IRepositories
{
    public interface IBlockedNameRepository
    {
        Task<IEnumerable<BlockedName>> GetBlockedNamesAsync();

        Task<BlockedName?> FindByNameAsync(string name);

        Task<BlockedName> AddAsync(BlockedName blockedName);

        void Remove(BlockedName blockedName);
    }
}
