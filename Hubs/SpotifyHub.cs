using Microsoft.AspNetCore.SignalR;

namespace BlazorWebAssemblySignalRApp.Server.Hubs;

public class SpotifyHub : Hub
{
    public async Task SendMessage( string user , string message )
    {
        await Clients.All.SendAsync( "ReceiveMessage" , user , message );
    }
}