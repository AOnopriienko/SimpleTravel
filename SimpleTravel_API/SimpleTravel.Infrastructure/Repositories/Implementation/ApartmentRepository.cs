using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleTravel.Infrastructure.Entities;

namespace SimpleTravel.Infrastructure.Repositories.Implementation
{
    public class ApartmentRepository : IRepository<Apartment>
    {
        private TripContext db;
        public ApartmentRepository()
        {
            this.db = new TripContext();
        }
        public IEnumerable<Apartment> GetList()
        {
            return db.Apartments.ToList();
        }
        public Apartment Get(Guid id)
        {
            return db.Apartments.Find(id);
        }
        public void Create(Apartment Apartment)
        {
            db.Apartments.Add(Apartment);
        }
        public void Update(Apartment Apartment)
        {
            db.Entry(Apartment).State = EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            Apartment Apartment = db.Apartments.Find(id);
            if (Apartment != null)
            {
                db.Apartments.Remove(Apartment);
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
