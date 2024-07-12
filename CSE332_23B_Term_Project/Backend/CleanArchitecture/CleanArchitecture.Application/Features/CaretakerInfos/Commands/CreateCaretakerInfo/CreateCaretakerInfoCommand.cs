using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

public class CreateCaretakerInfoCommand : IRequest<Response<int>>
{
    public string UserId { get; set; }  
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public int YearsOfExperience { get; set; }
    public string Skills { get; set; }
    public decimal HourlyRate { get; set; }
}
public class CreateCaretakerInfoCommandHandler : IRequestHandler<CreateCaretakerInfoCommand, Response<int>>
{
    private readonly ICaretakerInfoRepositoryAsync _caretakerInfoRepository;
    private readonly IMapper _mapper;

    public CreateCaretakerInfoCommandHandler(ICaretakerInfoRepositoryAsync caretakerInfoRepository, IMapper mapper)
    {
        _caretakerInfoRepository = caretakerInfoRepository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateCaretakerInfoCommand request, CancellationToken cancellationToken)
    {
        var caretakerInfo = _mapper.Map<CaretakerInfo>(request);
        caretakerInfo.UserId = request.UserId;  
        await _caretakerInfoRepository.AddAsync(caretakerInfo);
        return new Response<int>(caretakerInfo.Id);
    }
}

