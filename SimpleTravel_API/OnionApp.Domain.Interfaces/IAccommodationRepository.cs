using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionApp.Domain.Core;

namespace OnionApp.Domain.Interfaces
{
    public interface IApartmentRepository: IDisposable
    {
        IEnumerable<Apartment> GetApartmentList();
        Apartment GetApartment(Guid id);
        void Create(Apartment item);
        void Update(Apartment item);
        void Delete(Guid id);
        void Save();
    }
}
