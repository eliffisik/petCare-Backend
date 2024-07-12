using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string role, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, role, message);
        }
    }
}
