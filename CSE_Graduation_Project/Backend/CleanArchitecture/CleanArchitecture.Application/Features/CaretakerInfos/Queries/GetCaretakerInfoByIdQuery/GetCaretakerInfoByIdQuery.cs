using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.CaretakerInfos.Queries.GetCaretakerInfoByUserId
{
    public class GetCaretakerInfoByUserIdQuery : IRequest<Response<CaretakerInfo>>
    {
        public string UserId { get; set; }
    }

    public class GetCaretakerInfoByUserIdQueryHandler : IRequestHandler<GetCaretakerInfoByUserIdQuery, Response<CaretakerInfo>>
    {
        private readonly ICaretakerInfoRepositoryAsync _caretakerInfoRepository;

        public GetCaretakerInfoByUserIdQueryHandler(ICaretakerInfoRepositoryAsync caretakerInfoRepository)
        {
            _caretakerInfoRepository = caretakerInfoRepository;
        }

        public async Task<Response<CaretakerInfo>> Handle(GetCaretakerInfoByUserIdQuery request, CancellationToken cancellationToken)
        {
            var caretakerInfo = await _caretakerInfoRepository.GetByUserIdAsync(request.UserId);
            return new Response<CaretakerInfo>(caretakerInfo);
        }
    }
}
