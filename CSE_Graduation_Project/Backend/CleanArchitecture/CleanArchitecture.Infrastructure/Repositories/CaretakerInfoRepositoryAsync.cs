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
    public class CaretakerInfoRepositoryAsync : GenericRepositoryAsync<CaretakerInfo>, ICaretakerInfoRepositoryAsync
    {
        private readonly DbSet<CaretakerInfo> _caretakerInfos;

        public CaretakerInfoRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _caretakerInfos = dbContext.Set<CaretakerInfo>();
        }

        public async Task<CaretakerInfo> GetByUserIdAsync(string userId)
        {
            return await _caretakerInfos.FirstOrDefaultAsync(ci => ci.UserId == userId);
        }

        public async Task<IReadOnlyList<CaretakerInfo>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _caretakerInfos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
