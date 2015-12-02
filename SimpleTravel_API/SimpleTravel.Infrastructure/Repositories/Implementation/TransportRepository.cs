using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTravel.Infrastructure.Entities;
using System.Data.Entity;

namespace SimpleTravel.Infrastructure.Repositories.Implementation
{
    public class TransportRepository
    {
        private TripContext db;
        public TransportRepository()
        {
            this.db = new TripContext();
        }
        public IEnumerable<Transport> GetList()
        {
            return db.Transports.ToList();
        }
        public Transport Get(Guid id)
        {
            return db.Transports.Find(id);
        }
        public void Create(Transport Transport)
        {
            db.Transports.Add(Transport);
        }
        public void Update(Transport Transport)
        {
            db.Entry(Transport).State = EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            Transport Transport = db.Transports.Find(id);
            if (Transport != null)
            {
                db.Transports.Remove(Transport);
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
