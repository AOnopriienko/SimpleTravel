using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTravel.Infrastructure.Entities;
using System.Data.Entity;

namespace SimpleTravel.Infrastructure.Repositories.Implementation
{
    public class NotesInObjectRepository : IRepository<NotesInObject>
    {
        private TripContext db;
        public NotesInObjectRepository()
        {
            this.db = new TripContext();
        }
        public IEnumerable<NotesInObject> GetList()
        {
            return db.NotesInObjects.ToList();
        }
        public NotesInObject Get(Guid id)
        {
            return db.NotesInObjects.Find(id);
        }
        public void Create(NotesInObject NotesInObject)
        {
            db.NotesInObjects.Add(NotesInObject);
        }
        public void Update(NotesInObject NotesInObject)
        {
            db.Entry(NotesInObject).State = EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            NotesInObject NotesInObject = db.NotesInObjects.Find(id);
            if (NotesInObject != null)
            {
                db.NotesInObjects.Remove(NotesInObject);
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
