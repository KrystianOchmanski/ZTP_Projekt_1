using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Application.IServices
{
    public interface IBlockedNameService
    {
        Task<bool> IsNameBlockedAsync(string name);

        Task<IEnumerable<BlockedName>> GetBlockedNamesAsync();

        Task<BlockedName> AddAsync(BlockedName blockedName);

        Task<bool> RemoveAsync(int id);

        Task<bool> RemoveAsync(string name);
    }
}
