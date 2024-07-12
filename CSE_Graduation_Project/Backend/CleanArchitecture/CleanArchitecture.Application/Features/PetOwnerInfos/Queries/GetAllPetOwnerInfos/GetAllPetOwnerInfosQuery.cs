using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.PetOwnerInfos.Queries.GetAllPetOwnerInfos
{
    public class GetAllPetOwnerInfosQuery : IRequest<PagedResponse<IEnumerable<GetAllPetOwnerInfosViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllPetOwnerInfosQueryHandler : IRequestHandler<GetAllPetOwnerInfosQuery, PagedResponse<IEnumerable<GetAllPetOwnerInfosViewModel>>>
    {
        private readonly IPetOwnerInfoRepositoryAsync _petownerInfoRepository;
        private readonly IMapper _mapper;

        public GetAllPetOwnerInfosQueryHandler(IPetOwnerInfoRepositoryAsync petownerInfoRepository, IMapper mapper)
        {
            _petownerInfoRepository = petownerInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllPetOwnerInfosViewModel>>> Handle(GetAllPetOwnerInfosQuery request, CancellationToken cancellationToken)
        {
            var petownerInfoList = await _petownerInfoRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);
            var petownerInfoViewModel = _mapper.Map<IEnumerable<GetAllPetOwnerInfosViewModel>>(petownerInfoList);
            return new PagedResponse<IEnumerable<GetAllPetOwnerInfosViewModel>>(petownerInfoViewModel, request.PageNumber, request.PageSize);
        }
    }
}
