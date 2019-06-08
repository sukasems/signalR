using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        // [HubMethodName("SendMessageToUser")]
        // public Task DirectMessage(string user, string message)
        // {
        //     return Clients.User(user).SendAsync("ReceiveMessage", message);
        // }
        
        public async Task SendMessage(string user, string message, string to)
        {
            // send message back to caller.
            //await Clients.Caller.SendAsync("ReceiveMessage", user, message + "-Test", phone);

            // send message to all connection except caller.
            //await Clients.Others.SendAsync("ReceiveMessage", user, message + "-Test", phone);

            // send message to all connection include caller.
            await Clients.All.SendAsync("ReceiveMessage", user, message, to);

            // send message to group
            //await Clients.Group("SignalR User").SendAsync("ReceiveMessage", user, message, phone);
        }
    }
}