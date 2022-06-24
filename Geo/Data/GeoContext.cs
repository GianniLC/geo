using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Geo.Models;

namespace Geo.Data
{
    public class GeoContext : DbContext
    {
        public GeoContext (DbContextOptions<GeoContext> options)
            : base(options)
        {
        }

        public DbSet<Geo.Models.User>? User { get; set; }
    }
}
