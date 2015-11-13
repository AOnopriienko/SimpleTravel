using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace SimpleTravel.Infrastructure.Repositories.Implementation
{
    public class TripRepository: IRepository<Trip>
    {
        private TripContext db;
        public TripRepository()
        {
            this.db = new TripContext();
        }
        public IEnumerable<Trip> GetList()
        {
            return db.Trips.ToList();
        }
        public Trip Get(Guid id)
        {
            return db.Trips.Find(id);
        }
        public void Create(Trip trip)
        {
            db.Trips.Add(trip);
        }
        public void Update(Trip trip)
        {
            db.Entry(trip).State = EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            Trip trip = db.Trips.Find(id);
            if (trip != null)
            {
                db.Trips.Remove(trip);
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
