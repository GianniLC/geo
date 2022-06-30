using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Geo.Data;
using System;
using System.Linq;

namespace Geo.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GeoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GeoContext>>()))
            {
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        fname = "Gianni",
                        lname = "Cimanez",
                    },

                    new User
                    {
                        fname = "Kyara",
                        lname = "De winter",
                    },

                    new User
                    {
                        fname = "Mike",
                        lname = "Hermsen",
                    },

                    new User
                    {
                        fname = "Rick",
                        lname = "de Jong",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}