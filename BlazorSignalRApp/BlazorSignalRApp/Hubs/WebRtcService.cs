using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRApp.Hubs;

public class WebRtcService : Hub
{
    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"{Context.ConnectionId} connected");
        return base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception e)
    {
        Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
        await base.OnDisconnectedAsync(e);
    }

    public async Task Send(string message)
    {
        Console.WriteLine(message);
        await Clients.Others.SendAsync("Receive", message);
    }
}