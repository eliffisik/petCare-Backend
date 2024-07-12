using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Pets.Commands.CreatePet
{
    public class CreatePetCommand : IRequest<Response<int>>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }

    }

  public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, Response<int>>
    {
        private readonly IPetRepositoryAsync _petRepository;
        private readonly IMapper _mapper;

        public CreatePetCommandHandler(IPetRepositoryAsync petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            var pet = _mapper.Map<Pet>(request);
            await _petRepository.AddAsync(pet);
            return new Response<int>(pet.Id);
        }
    }

}