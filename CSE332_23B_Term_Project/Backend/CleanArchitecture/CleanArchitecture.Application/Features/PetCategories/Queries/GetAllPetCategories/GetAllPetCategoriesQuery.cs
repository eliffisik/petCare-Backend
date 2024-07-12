using AutoMapper;
using CleanArchitecture.Core.Features.PetCategories.Queries;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.PetCategories.Queries.GetAllPetCategories
{
    public class GetAllPetCategoriesQuery : IRequest<PagedResponse<IEnumerable<GetAllPetCategoriesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllPetCategoriesQueryHandler : IRequestHandler<GetAllPetCategoriesQuery, PagedResponse<IEnumerable<GetAllPetCategoriesViewModel>>>
    {
        private readonly IPetCategoryRepositoryAsync _petCategoriesRepository;
        private readonly IMapper _mapper;

        public GetAllPetCategoriesQueryHandler(IPetCategoryRepositoryAsync petCategoryRepository, IMapper mapper)
        {
            _petCategoriesRepository = petCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllPetCategoriesViewModel>>> Handle(GetAllPetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllPetCategoriesParameter>(request);
            var pets = await _petCategoriesRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var petsViewModel = _mapper.Map<IEnumerable<GetAllPetCategoriesViewModel>>(pets);
            return new PagedResponse<IEnumerable<GetAllPetCategoriesViewModel>>(petsViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
