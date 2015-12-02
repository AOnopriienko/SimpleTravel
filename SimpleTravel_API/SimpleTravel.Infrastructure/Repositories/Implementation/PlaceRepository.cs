using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTravel.Infrastructure.Entities;
using System.Data.Entity;

namespace SimpleTravel.Infrastructure.Repositories.Implementation
{
    public class PlaceRepository: IRepository<Place>
    {
        private TripContext db;
        public PlaceRepository()
        {
            this.db = new TripContext();
        }
        public IEnumerable<Place> GetList()
        {
            return db.Places.ToList();
        }
        public Place Get(Guid id)
        {
            return db.Places.Find(id);
        }
        public void Create(Place Place)
        {
            db.Places.Add(Place);
        }
        public void Update(Place Place)
        {
            db.Entry(Place).State = EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            Place Place = db.Places.Find(id);
            if (Place != null)
            {
                db.Places.Remove(Place);
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
