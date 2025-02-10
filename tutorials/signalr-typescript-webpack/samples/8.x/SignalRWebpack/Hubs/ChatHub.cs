using Microsoft.AspNetCore.SignalR;

namespace SignalRWebpack.Hubs;

public class ChatHub : Hub
{
    public async Task JoinChat(string username)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, username);
        await Clients.Group(username).SendAsync("messageReceived", username, $"{username} has joined the chat.");
    }

    public async Task NewMessage(string username, string message)
    {
        await Clients.Group(username).SendAsync("messageReceived", username, message);

        // await Task.Delay(3000); // Wait for 3 seconds
        // await Clients.Group(username).SendAsync("messageReceived", username, "Auto reply: I'm not available right now.");
    }
}
