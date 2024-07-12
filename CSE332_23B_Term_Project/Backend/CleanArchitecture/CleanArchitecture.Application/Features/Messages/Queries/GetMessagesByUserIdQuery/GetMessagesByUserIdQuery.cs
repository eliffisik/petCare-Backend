using CleanArchitecture.Core.Entities;
using MediatR;
using System.Collections.Generic;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Features.Messages.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace CleanArchitecture.Core.Features.Messages.Queries
{
    public class GetMessagesByUserIdQuery : IRequest<IEnumerable<Message>>
    {
        public string UserId { get; set; }
        public string Role { get; set; }
    }
    public class GetMessagesByUserIdQueryHandler : IRequestHandler<GetMessagesByUserIdQuery, IEnumerable<Message>>
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessagesByUserIdQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<Message>> Handle(GetMessagesByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _messageRepository.GetMessagesByUserIdAndRoleAsync(request.UserId, request.Role);
        }
    }
}

