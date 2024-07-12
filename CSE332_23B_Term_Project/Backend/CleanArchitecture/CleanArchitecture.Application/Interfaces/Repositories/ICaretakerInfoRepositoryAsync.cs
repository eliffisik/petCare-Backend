using CleanArchitecture.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface ICaretakerInfoRepositoryAsync : IGenericRepositoryAsync<CaretakerInfo>
    {
        Task<CaretakerInfo> GetByUserIdAsync(string userId);
        Task<IReadOnlyList<CaretakerInfo>> GetPagedReponseAsync(int pageNumber, int pageSize);
    }
}
