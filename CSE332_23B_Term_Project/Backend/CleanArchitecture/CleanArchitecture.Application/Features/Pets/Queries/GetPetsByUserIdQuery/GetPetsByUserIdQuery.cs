using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Pets.Queries.GetPetsByUserIdQuery
{
    public class GetPetsByUserIdQuery : IRequest<Response<Pet>>
    {
        public string UserId { get; set; }
    }

    public class GetPetsByUserIdQueryHandler : IRequestHandler<GetPetsByUserIdQuery, Response<Pet>>
    {
        private readonly IPetRepositoryAsync _petRepository;

        public GetPetsByUserIdQueryHandler(IPetRepositoryAsync petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<Response<Pet>> Handle(GetPetsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var pet = await _petRepository.GetByUserIdAsync(request.UserId);
            return new Response<Pet>(pet);
        }
    }
}
