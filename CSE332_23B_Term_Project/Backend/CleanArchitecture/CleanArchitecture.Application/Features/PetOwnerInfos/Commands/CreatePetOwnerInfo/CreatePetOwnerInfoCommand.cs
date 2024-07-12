using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

public class CreatePetOwnerInfoCommand : IRequest<Response<int>>
{
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
  
}
public class CreatePetOwnerInfoCommandHandler : IRequestHandler<CreatePetOwnerInfoCommand, Response<int>>
{
    private readonly IPetOwnerInfoRepositoryAsync _petownerInfoRepository;
    private readonly IMapper _mapper;

    public CreatePetOwnerInfoCommandHandler(IPetOwnerInfoRepositoryAsync petownerInfoRepository, IMapper mapper)
    {
        _petownerInfoRepository = petownerInfoRepository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreatePetOwnerInfoCommand request, CancellationToken cancellationToken)
    {
        var petownerInfo = _mapper.Map<PetOwnerInfo>(request);
        petownerInfo.UserId = request.UserId;
        await _petownerInfoRepository.AddAsync(petownerInfo);
        return new Response<int>(petownerInfo.Id);
    }
}

