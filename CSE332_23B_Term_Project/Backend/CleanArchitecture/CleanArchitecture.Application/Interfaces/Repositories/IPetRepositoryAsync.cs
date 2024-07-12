using CleanArchitecture.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface IPetRepositoryAsync : IGenericRepositoryAsync<Pet>
    {
        Task<Pet> GetByUserIdAsync(string userId);
        Task<IReadOnlyList<Pet>> GetPagedReponseAsync(int pageNumber, int pageSize);
    }
}
