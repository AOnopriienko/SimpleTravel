using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTravel.Infrastructure.Entities;

namespace SimpleTravel.Infrastructure
{
    public interface IReservation
    {
        void MakeReservation(Apartment apartment);
    }
}
