using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProcessToDoItemUpdatesWorkerService.Entities;
using ProcessToDoItemUpdatesWorkerService.Repositories;
using ProcessToDoItemUpdatesWorkerService.Repositories.Interfaces;

namespace ProcessToDoItemUpdatesWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.Configure<DatabaseConnectionStrings>(hostContext.Configuration.GetSection(nameof(DatabaseConnectionStrings)));
                    services.AddScoped<IToDoItemUpdateRepository, ToDoItemUpdateRepository>();
                    services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
                });
        }
    }
}
