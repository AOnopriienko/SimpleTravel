using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTravel.Infrastructure.Entities;
using System.Data.Entity;

namespace SimpleTravel.Infrastructure.Repositories.Implementation
{
    public class NoteRepository: IRepository<Note>
    {
        private TripContext db;
        public NoteRepository()
        {
            this.db = new TripContext();
        }
        public IEnumerable<Note> GetList()
        {
            return db.Notes.ToList();
        }
        public Note Get(Guid id)
        {
            return db.Notes.Find(id);
        }
        public void Create(Note Note)
        {
            db.Notes.Add(Note);
        }
        public void Update(Note Note)
        {
            db.Entry(Note).State = EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            Note Note = db.Notes.Find(id);
            if (Note != null)
            {
                db.Notes.Remove(Note);
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
