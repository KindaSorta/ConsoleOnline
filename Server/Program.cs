using Microsoft.AspNetCore.SignalR;
namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSignalR();



            var app = builder.Build();
            
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.MapHub<LowTechHub>("/lowTechHub");

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}