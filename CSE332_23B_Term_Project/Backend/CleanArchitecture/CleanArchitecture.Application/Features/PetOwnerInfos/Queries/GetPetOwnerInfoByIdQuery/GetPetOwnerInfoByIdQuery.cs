using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.PetOwnerInfos.Queries.GetPetOwnerInfoByUserId
{
    public class GetPetOwnerInfoByUserIdQuery : IRequest<Response<PetOwnerInfo>>
    {
        public string UserId { get; set; }
    }

    public class GetPetOwnerInfoByUserIdQueryHandler : IRequestHandler<GetPetOwnerInfoByUserIdQuery, Response<PetOwnerInfo>>
    {
        private readonly IPetOwnerInfoRepositoryAsync _petownerInfoRepository;

        public GetPetOwnerInfoByUserIdQueryHandler(IPetOwnerInfoRepositoryAsync petownerInfoRepository)
        {
            _petownerInfoRepository = petownerInfoRepository;
        }

        public async Task<Response<PetOwnerInfo>> Handle(GetPetOwnerInfoByUserIdQuery request, CancellationToken cancellationToken)
        {
            var petownerInfo = await _petownerInfoRepository.GetByUserIdAsync(request.UserId);
            return new Response<PetOwnerInfo>(petownerInfo);
        }
    }
}
