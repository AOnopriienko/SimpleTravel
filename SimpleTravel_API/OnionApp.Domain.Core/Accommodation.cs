using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Domain.Core
{
    public class Accommodation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AccommodationType TypeId { get; set; }
        public string Address { get; set; }
    }

    public enum AccommodationType
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
