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

                if(context.AbsenceTypes.Count() == 0)
                {
                    context.AbsenceTypes.AddRange(
                        new AbsenceType
                        {
                            TypeOfAbsence = "Personal",
                            Description = "Personal reasons"
                        },

                        new AbsenceType
                        {
                            TypeOfAbsence = "Sick",
                            Description = "For sick days"
                        },

                        new AbsenceType {
                            TypeOfAbsence = "Vacation",
                            Description = "Required for vacation days"
                        }
                    );
                }

                // Seed data for absencetypes

                // Check for users last to seed
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                // Seed data for Users
                context.User.AddRange(
                    new User
                    {
                        fname = "Admin",
                        lname = "Admin",
                        role = "Admin"
                    },
                    new User
                    {
                        fname = "Gianni",
                        lname = "Cimanez",
                        role = "HR"
                    },

                    new User
                    {
                        fname = "Kyara",
                        lname = "De winter",
                        role = "HR"
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