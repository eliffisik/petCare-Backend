using AutoMapper;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Pets.Queries.GetAllPets
{
    public class GetAllPetsQuery : IRequest<PagedResponse<IEnumerable<GetAllPetsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllPetsQueryHandler : IRequestHandler<GetAllPetsQuery, PagedResponse<IEnumerable<GetAllPetsViewModel>>>
    {
        private readonly IPetRepositoryAsync _petRepository;
        private readonly IMapper _mapper;

        public GetAllPetsQueryHandler(IPetRepositoryAsync petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllPetsViewModel>>> Handle(GetAllPetsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllPetsParameter>(request);
            var pets = await _petRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var petsViewModel = _mapper.Map<IEnumerable<GetAllPetsViewModel>>(pets);
            return new PagedResponse<IEnumerable<GetAllPetsViewModel>>(petsViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
