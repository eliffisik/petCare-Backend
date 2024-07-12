using CleanArchitecture.Core.Features.Messages.Commands;
using CleanArchitecture.Core.Features.Messages.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostMessage(CreateMessageCommand command)
        {
            var messageId = await _mediator.Send(command);
            return Ok(messageId);
        }

        [HttpGet("{userId}/{role}")]
        public async Task<IActionResult> GetMessages(string userId, string role)
        {
            var query = new GetMessagesByUserIdQuery { UserId = userId, Role = role };
            var messages = await _mediator.Send(query);
            return Ok(messages);
        }


        [HttpGet("conversation/{userId1}/{userId2}")]
        public async Task<IActionResult> GetConversation(string userId1, string userId2)
        {
            var query = new GetConversationQuery { UserId1 = userId1, UserId2 = userId2 };
            var messages = await _mediator.Send(query);
            return Ok(messages);
        }


    }
}
