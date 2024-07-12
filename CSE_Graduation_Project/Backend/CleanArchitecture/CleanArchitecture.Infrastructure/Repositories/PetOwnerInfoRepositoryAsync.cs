using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class PetOwnerInfoRepositoryAsync : GenericRepositoryAsync<PetOwnerInfo>, IPetOwnerInfoRepositoryAsync
    {
        private readonly DbSet<PetOwnerInfo> _petownerInfos;

        public PetOwnerInfoRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _petownerInfos = dbContext.Set<PetOwnerInfo>();
        }

        public async Task<PetOwnerInfo> GetByUserIdAsync(string userId)
        {
            return await _petownerInfos.FirstOrDefaultAsync(ci => ci.UserId == userId);
        }

        public async Task<IReadOnlyList<PetOwnerInfo>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _petownerInfos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
