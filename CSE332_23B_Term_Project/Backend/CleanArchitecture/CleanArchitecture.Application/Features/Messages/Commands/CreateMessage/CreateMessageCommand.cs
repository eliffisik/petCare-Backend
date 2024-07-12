using MediatR;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Features.Messages.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace CleanArchitecture.Core.Features.Messages.Commands
{
    public class CreateMessageCommand : IRequest<int>
    {
        public string SenderId { get; set; }
        public string SenderRole { get; set; }
        public string ReceiverId { get; set; }
        public string ReceiverRole { get; set; }
        public string Content { get; set; }
    }

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, int>
    {
        private readonly IMessageRepository _messageRepository;

        public CreateMessageCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Message
            {
                SenderId = request.SenderId,
                SenderRole = request.SenderRole,
                ReceiverId = request.ReceiverId,
                ReceiverRole = request.ReceiverRole,
                Content = request.Content,
                Timestamp = DateTime.UtcNow
            };

            await _messageRepository.AddMessageAsync(message);
            return message.Id;
        }
    }
}

