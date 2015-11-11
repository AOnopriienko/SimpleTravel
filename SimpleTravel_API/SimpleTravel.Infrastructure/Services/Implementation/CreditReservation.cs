using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTravel.Infrastructure
{
    public class CreditReservation : IReservation
    {
        private readonly IApartmentRepository repository;
        public CreditReservation(IApartmentRepository repo)
        {
            this.repository = repo;
        }
        public void MakeReservation(Apartment accomodation)
        {
            //код бронирования жилья с помощью кредитной карты
        }
    }
}
