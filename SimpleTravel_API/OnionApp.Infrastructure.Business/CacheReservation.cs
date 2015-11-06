using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionApp.Domain.Core;
using OnionApp.Services.Interfaces;

namespace OnionApp.Infrastructure.Business
{
    public class CacheReservation : IReservation
    {
        public void MakeReservation(Accommodation accomodation)
        {
            //код бронирования жилья при оплате наличностью
        }
    }
}
