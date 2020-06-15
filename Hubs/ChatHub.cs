using System.Threading.Tasks;
using chat_app.Data;
using Microsoft.AspNetCore.SignalR;

namespace chat_app.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task EditMessage(long messageId, string newContent)
        {
            // check if it is my message
            await Clients.All.SendAsync("ReceiveMessageEdit", messageId, newContent);
        }

        public async Task DeleteMessage(long messageId)
        {
            // check if it is my message
            await Clients.All.SendAsync("ReceiveMessageDelete", messageId);
        }

        public async Task JoinChat(long userId)
        {
            // send message to all others that user joined
        }

        public async Task LeaveChat(long userId) {
            // send message to all others that user left
        }
    }
}