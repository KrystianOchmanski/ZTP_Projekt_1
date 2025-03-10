﻿using ZTP_Projekt_1.Application.IRepositories;
using ZTP_Projekt_1.Application.IServices;
using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Application.Services
{
    public class BlockedNameService : IBlockedNameService
    {
        private readonly IBlockedNameRepository _blockedNameRepository;

        public BlockedNameService(IBlockedNameRepository blockedNameRepository)
        {
            _blockedNameRepository = blockedNameRepository;
        }

        public async Task<BlockedName> AddAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is not valid");

            if (await IsNameBlockedAsync(name))
                throw new ArgumentException("Name is already blocked");

            var blockedName = await _blockedNameRepository.AddAsync(name);
            return blockedName;
        }

        public async Task<IEnumerable<BlockedName>> GetBlockedNamesAsync()
        {
            return await _blockedNameRepository.GetBlockedNamesAsync();
        }

		public async Task<BlockedName?> GetById(int id)
		{
			return await _blockedNameRepository.GetById(id);
		}

		public async Task<bool> IsNameBlockedAsync(string name)
        {
            return await _blockedNameRepository.FindByNameAsync(name) != null;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var blockedName = await _blockedNameRepository.GetById(id);
            if (blockedName == null)
                throw new KeyNotFoundException($"Blocked name was not found");

            return await _blockedNameRepository.Remove(blockedName);
        }
    }
}
