using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Pets.Commands.CreatePetCategory
{
    public class CreatePetCategoryCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }

    public class CreatePetCategoryCommandHandler : IRequestHandler<CreatePetCategoryCommand, Response<int>>
    {
        private readonly IPetCategoryRepositoryAsync _petCategoryRepository;
        private readonly IMapper _mapper;

        public CreatePetCategoryCommandHandler(IPetCategoryRepositoryAsync petCategoryRepository, IMapper mapper)
        {
            _petCategoryRepository = petCategoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePetCategoryCommand request, CancellationToken cancellationToken)
        {
            var petCategory = _mapper.Map<PetCategory>(request);
            await _petCategoryRepository.AddAsync(petCategory);
            return new Response<int>(petCategory.Id);
        }
    }
}