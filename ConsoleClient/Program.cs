using Microsoft.AspNetCore.SignalR.Client;

namespace ConsoleClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5121/lowTechHub")
                .Build();

            hubConnection.On<string>("UpdatePlayerName", (name) =>
            {
                Console.WriteLine($"Name Updated: {name}");
            });

            await hubConnection.StartAsync();

            Console.WriteLine("Connected...");
            await hubConnection.InvokeAsync<string>("ChangeName", "Human");

            string input = String.Empty;
            do
            {
                input = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(input))
                {
                    await hubConnection.InvokeAsync<string>("ChangeName", input);
                } 

            } while (!String.IsNullOrWhiteSpace(input));

            await hubConnection.StopAsync();
            Console.WriteLine("Disconnecting");
        }
    }
}