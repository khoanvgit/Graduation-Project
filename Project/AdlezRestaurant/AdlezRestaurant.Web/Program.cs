using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdlezRestaurant.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(services =>
                {
                    // Add the required Quartz.NET services
                    services.AddQuartz(q =>
                    {
                        q.UseMicrosoftDependencyInjectionJobFactory();
                        // Create a "key" for the job
                        var jobKey = new JobKey("TableStatusJob");
                        var jobKey1 = new JobKey("CheckRoleJob");

                        // Register the job with the DI container
                        q.AddJob<TableStatusJob>(opts => opts.WithIdentity(jobKey));
                        q.AddJob<CheckRoleJob>(opts => opts.WithIdentity(jobKey1));

                        // Create a trigger for the job
                        q.AddTrigger(opts => opts
                            .ForJob(jobKey)
                            .WithIdentity("TableStatusJob-trigger") // give the trigger a unique name
                            .WithCronSchedule("*/3 * * * * ?")); // run every 3 minutes

                        q.AddTrigger(opts => opts
                            .ForJob(jobKey1)
                            .WithIdentity("CheckRoleJob-trigger")
                            .WithCronSchedule("*/30 * * * * ?")); // run every 30 minutes
                    });

                    // Add the Quartz.NET hosted service

                    services.AddQuartzHostedService(
                        q => q.WaitForJobsToComplete = true);
                });
        
    }
}
