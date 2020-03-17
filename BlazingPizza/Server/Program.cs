using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using BlazingPizza.Server.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BlazingPizza.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Host = BuildWebHost(args);
            var scopeFactory = Host.Services.GetRequiredService<IServiceScopeFactory>();
            using (var Scope = scopeFactory.CreateScope())
            {
                var Context = Scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
                if (Context.Specials.Count() == 0)
                {
                    SeedData.Initialize(Context);
                }
            }
            Host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build())
                .UseStartup<Startup>()
                .Build();
    }
}
