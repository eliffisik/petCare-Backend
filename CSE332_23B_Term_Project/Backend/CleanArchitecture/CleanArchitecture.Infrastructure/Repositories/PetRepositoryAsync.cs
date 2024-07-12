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
    public class PetRepositoryAsync : GenericRepositoryAsync<Pet>, IPetRepositoryAsync
    {
        private readonly DbSet<Pet> _pets;

        public PetRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _pets = dbContext.Set<Pet>();
        }

        public async Task<Pet> GetByUserIdAsync(string userId)
        {
            return await _pets.FirstOrDefaultAsync(ci => ci.UserId == userId);
        }

        public async Task<IReadOnlyList<Pet>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _pets
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
