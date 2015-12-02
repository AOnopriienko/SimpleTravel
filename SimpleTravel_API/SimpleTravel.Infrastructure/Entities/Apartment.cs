using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTravel.Infrastructure.Entities
{
    public class Apartment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ApartmentType TypeId { get; set; }
        public string Address { get; set; }
    }

    public enum ApartmentType
    {
        Hotel,
        Motel,
        Hostel,
        PrivateHouse,
        Camping,
        Roadhouse,
        CasinoHotel
    }
}
