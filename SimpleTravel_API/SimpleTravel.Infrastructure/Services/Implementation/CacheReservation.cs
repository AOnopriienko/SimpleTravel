﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTravel.Infrastructure.Entities;

namespace SimpleTravel.Infrastructure
{
    public class CacheReservation : IReservation
    {
        public void MakeReservation(Apartment accomodation)
        {
            //код бронирования жилья при оплате наличностью
        }
    }
}
