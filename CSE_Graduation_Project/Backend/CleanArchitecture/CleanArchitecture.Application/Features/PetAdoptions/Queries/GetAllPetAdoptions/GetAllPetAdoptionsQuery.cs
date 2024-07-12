using AutoMapper;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.PetAdoptions.Queries.GetAllPetAdoptions
{
    public class GetAllPetAdoptionsQuery : IRequest<PagedResponse<IEnumerable<GetAllPetAdoptionsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllPetAdoptionsQueryHandler : IRequestHandler<GetAllPetAdoptionsQuery, PagedResponse<IEnumerable<GetAllPetAdoptionsViewModel>>>
    {
        private readonly IPetAdoptionRepositoryAsync _petadoptionRepository;
        private readonly IMapper _mapper;

        public GetAllPetAdoptionsQueryHandler(IPetAdoptionRepositoryAsync petRepository, IMapper mapper)
        {
            _petadoptionRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllPetAdoptionsViewModel>>> Handle(GetAllPetAdoptionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllPetAdoptionsParameter>(request);
            var petadoptions = await _petadoptionRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var petadoptionsViewModel = _mapper.Map<IEnumerable<GetAllPetAdoptionsViewModel>>(petadoptions);
            return new PagedResponse<IEnumerable<GetAllPetAdoptionsViewModel>>(petadoptionsViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
