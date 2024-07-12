using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Messages.Queries
{
    public class GetConversationQuery : IRequest<IEnumerable<Message>>
    {
        public string UserId1 { get; set; }
        public string UserId2 { get; set; }
    }
    public class GetConversationQueryHandler : IRequestHandler<GetConversationQuery, IEnumerable<Message>>
    {
        private readonly IMessageRepository _messageRepository;

        public GetConversationQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<Message>> Handle(GetConversationQuery request, CancellationToken cancellationToken)
        {
            return await _messageRepository.GetConversationBetweenUsersAsync(request.UserId1, request.UserId2);
        }
    }
}

