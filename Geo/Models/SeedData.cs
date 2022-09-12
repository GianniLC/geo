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
                // Seed data for absencetypes
                context.AbsenceTypes.AddRange(
                    new AbsenceType
                    {
                        ID = 1,
                        TypeOfAbsence = "Personal",
                        Description = "Personal reasons"
                    },

                    new AbsenceType
                    {
                        ID=2,
                        TypeOfAbsence = "Sick",
                        Description = "For sick days"
                    },

                    new AbsenceType
                    {
                        ID=3,
                        TypeOfAbsence = "Vacation",
                        Description = "Required for vacation days"
                    }
                );
                
                // Check for users last to seed
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                // Seed data for Users
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
                    },

                    new User
                    {
                        fname = "Eva",
                        lname = "Dekkers",
                    }
                );

                context.SaveChanges();
            }
        }
    }
}