using CleanArchitecture.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface IPetOwnerInfoRepositoryAsync : IGenericRepositoryAsync<PetOwnerInfo>
    {
        Task<PetOwnerInfo> GetByUserIdAsync(string userId);
        Task<IReadOnlyList<PetOwnerInfo>> GetPagedReponseAsync(int pageNumber, int pageSize);
    }
}
