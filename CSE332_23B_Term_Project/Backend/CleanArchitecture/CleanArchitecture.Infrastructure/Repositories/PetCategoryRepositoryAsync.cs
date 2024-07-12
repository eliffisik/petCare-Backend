using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class PetCategoryRepositoryAsync : GenericRepositoryAsync<PetCategory>, IPetCategoryRepositoryAsync
    {
        private readonly DbSet<PetCategory> _categories;

        public PetCategoryRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _categories = dbContext.Set<PetCategory>();
        }

       
    }
}
