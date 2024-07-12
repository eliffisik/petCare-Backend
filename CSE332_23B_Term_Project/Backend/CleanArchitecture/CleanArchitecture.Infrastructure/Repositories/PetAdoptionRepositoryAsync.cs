using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class PetAdoptionRepositoryAsync : GenericRepositoryAsync<PetAdoption>, IPetAdoptionRepositoryAsync
    {
        private readonly DbSet<PetAdoption> _petAdoptions;

        public PetAdoptionRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _petAdoptions = dbContext.Set<PetAdoption>();
        }


    }
}
