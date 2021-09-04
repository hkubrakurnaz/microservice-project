using System;
using System.Linq;
using System.Security.Policy;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data.Mock
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                context.Platforms.AddRange(
                    new Platform(){Id = 1, Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"},
                    new Platform(){Id = 2, Name = "Sql Server Express", Publisher = "Microsoft", Cost = "Free"},
                    new Platform(){Id = 3, Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free"}
                );

                context.SaveChanges();
            }
            else
            {
                // TODO: Logging will be added
                Console.WriteLine("We already have data.");
            }
        }
    }
}