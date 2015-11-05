using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionApp.Domain.Core;

namespace OnionApp.Domain.Interfaces
{
    public interface ITripRepository: IDisposable
    {
        IEnumerable<Trip> GetTripList();
        Trip GetTrip(Guid id);
        void Create(Trip item);
        void Update(Trip item);
        void Delete(Trip item);
        void Save(Trip item);
    }
}
