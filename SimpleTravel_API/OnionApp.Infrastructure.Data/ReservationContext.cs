using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OnionApp.Domain.Core;
using OnionApp.Domain.Interfaces;

namespace OnionApp.Infrastructure.Data
{
    public class ReservationContext: DbContext
    {
        public DbSet<Accommodation> Accommodations { get; set; }
    }

    public class AccommodationRepository: IAccommodationRepository
    {
        private ReservationContext db;
        public AccommodationRepository()
        {
            this.db = new ReservationContext();
        }
        public IEnumerable<Accommodation> GetAccommodationList()
        {
            return db.Accommodations.ToList();
        }
        public Accommodation GetAccommodation(Guid id)
        {
            return db.Accommodations.Find(id);
        }
        public void Create(Accommodation accommodation)
        {
            db.Accommodations.Add(accommodation);
        }
        public void Update(Accommodation accommodation)
        {
            db.Entry(accommodation).State = EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            Accommodation accommodation = db.Accommodations.Find(id);
            if (accommodation != null)
            {
                db.Accommodations.Remove(accommodation);
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
