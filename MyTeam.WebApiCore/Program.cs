using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyTeam.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeam.WebApiCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
                

            using(var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var dbInitial = service.GetRequiredService<IDatabaseInitializer>();
                try
                {
                 dbInitial.SeedSampleData().Wait();
                }
                catch (Exception ex)
                {

                    var msg = ex.Message;
                }
              
            }
                
                host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
