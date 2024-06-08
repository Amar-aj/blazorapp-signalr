using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRApp.Hubs;

public class ChatHub : Hub
{

    public override async Task OnConnectedAsync()
    {
        ConnectedUser.Ids.Add(Context.ConnectionId);

    }
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        ConnectedUser.Ids.Remove(Context.ConnectionId);
    }


    public async Task GetAllConnections()
    {
        await Clients.All.SendAsync("ReceiveAllConnections", ConnectedUser.Ids);
    }

    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    public async Task SendGroupMessage(string user, string message, string roomId)
    {
        await Clients.Group(roomId).SendAsync("ReceiveGroupMessage", user, message);
    }





    public Task JoinRoom(string roomName)
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
    }

    public Task LeaveRoom(string roomName)
    {
        return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
    }
}

public static class ConnectedUser
{
    public static List<string> Ids = new List<string>();
}