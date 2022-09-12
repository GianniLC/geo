using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Geo.Models;
using System.Runtime.CompilerServices;

namespace Geo.Data
{
    public class GeoContext : DbContext
    {
        public GeoContext (DbContextOptions<GeoContext> options)
            : base(options)
        {
           
        }

        public DbSet<Geo.Models.User>? User { get; set; }

        public DbSet<Geo.Models.Absence>? Absence { get; set; }

        public DbSet<Geo.Models.AbsenceType> AbsenceTypes { get; set; }
    }
}
