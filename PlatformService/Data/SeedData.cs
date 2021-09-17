using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Data
{
    public static class Seed
    {
        public static void SeedData(IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                PopulateValue(scope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        public static void PopulateValue(AppDbContext dbContext)
        {
            if (!dbContext.PlatForms.Any())
            {
                dbContext.AddRange(
                    new Platform { Name = "Dot Net Core", Publisher = "Microsoft", Cost = "Free" },
                    new Platform { Name = "Angular", Publisher = "Google", Cost = "Free" }
                    );
                dbContext.SaveChanges();
            }
        }
    }
}
