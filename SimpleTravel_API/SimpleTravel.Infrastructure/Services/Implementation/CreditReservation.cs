using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTravel.Infrastructure.Entities;

namespace SimpleTravel.Infrastructure
{
    public class CreditReservation : IReservation
    {
        private readonly IRepository<Apartment> repository;
        public CreditReservation(IRepository<Apartment> repo)
        {
            this.repository = repo;
        }
        public void MakeReservation(Apartment accomodation)
        {
            //код бронирования жилья с помощью кредитной карты
        }
    }
}
