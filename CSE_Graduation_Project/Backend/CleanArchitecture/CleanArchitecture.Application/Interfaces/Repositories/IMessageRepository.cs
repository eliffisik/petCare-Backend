using CleanArchitecture.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface IMessageRepository
    {
        Task AddMessageAsync(Message message);
        Task<IEnumerable<Message>> GetMessagesByUserIdAsync(string userId);
        Task<IEnumerable<Message>> GetMessagesByUserIdAndRoleAsync(string userId, string role);
        Task<IEnumerable<Message>> GetConversationBetweenUsersAsync(string userId1, string userId2);
    }
}
