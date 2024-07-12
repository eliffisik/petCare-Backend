using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.CaretakerInfos.Queries.GetAllCaretakerInfos
{
    public class GetAllCaretakerInfosQuery : IRequest<PagedResponse<IEnumerable<GetAllCaretakerInfosViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllCaretakerInfosQueryHandler : IRequestHandler<GetAllCaretakerInfosQuery, PagedResponse<IEnumerable<GetAllCaretakerInfosViewModel>>>
    {
        private readonly ICaretakerInfoRepositoryAsync _caretakerInfoRepository;
        private readonly IMapper _mapper;

        public GetAllCaretakerInfosQueryHandler(ICaretakerInfoRepositoryAsync caretakerInfoRepository, IMapper mapper)
        {
            _caretakerInfoRepository = caretakerInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllCaretakerInfosViewModel>>> Handle(GetAllCaretakerInfosQuery request, CancellationToken cancellationToken)
        {
            var caretakerInfoList = await _caretakerInfoRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);
            var caretakerInfoViewModel = _mapper.Map<IEnumerable<GetAllCaretakerInfosViewModel>>(caretakerInfoList);
            return new PagedResponse<IEnumerable<GetAllCaretakerInfosViewModel>>(caretakerInfoViewModel, request.PageNumber, request.PageSize);
        }
    }
}
