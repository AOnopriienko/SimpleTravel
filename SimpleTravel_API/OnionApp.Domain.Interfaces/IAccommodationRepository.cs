using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionApp.Domain.Core;

namespace OnionApp.Domain.Interfaces
{
    public interface IAccommodationRepository: IDisposable
    {
        IEnumerable<Accommodation> GetAccommodationList();
        Accommodation GetAccommodation(Guid id);
        void Create(Accommodation item);
        void Update(Accommodation item);
        void Delete(Accommodation item);
        void Save(Accommodation item);
    }
}
