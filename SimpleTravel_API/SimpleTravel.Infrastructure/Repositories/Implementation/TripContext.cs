using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleTravel.Infrastructure.Entities;

namespace SimpleTravel.Infrastructure.Repositories.Implementation
{
    public class TripContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NotesInObject> NotesInObjects { get; set; }
    }

}
