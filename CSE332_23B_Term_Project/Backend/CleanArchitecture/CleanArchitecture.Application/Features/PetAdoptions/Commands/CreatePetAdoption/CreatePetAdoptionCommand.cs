using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.PetAdoptions.Commands.CreatePetAdoption
{
    public class CreatePetAdoptionCommand : IRequest<Response<int>>
    {
        public string Type { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string AdditionalInfo { get; set; }
        public string Photo { get; set; }
        public int UserId { get; set; }

    }

    public class CreatePetAdoptionCommandHandler : IRequestHandler<CreatePetAdoptionCommand, Response<int>>
    {
        private readonly IPetAdoptionRepositoryAsync _petadoptionRepository;
        private readonly IMapper _mapper;

        public CreatePetAdoptionCommandHandler(IPetAdoptionRepositoryAsync petadoptionRepository, IMapper mapper)
        {
            _petadoptionRepository = petadoptionRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePetAdoptionCommand request, CancellationToken cancellationToken)
        {
            var petadoption = _mapper.Map<PetAdoption>(request);
            await _petadoptionRepository.AddAsync(petadoption);
            return new Response<int>(petadoption.Id);
        }
    }

}