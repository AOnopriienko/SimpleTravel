using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SimpleTravel.Infrastructure.Repositories.Implementation
{
    public class TripContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }

}
