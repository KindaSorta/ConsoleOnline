using Microsoft.AspNetCore.SignalR;

namespace Server
{
    public class LowTechHub : Hub
    {
        public async Task ChangeName(string name)
        {
            await Clients.All.SendAsync("UpdatePlayerName", name);
        }
    }
}
