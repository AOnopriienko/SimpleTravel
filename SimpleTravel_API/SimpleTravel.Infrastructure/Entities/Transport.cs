using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTravel.Infrastructure.Entities
{
    public class Transport
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public TransportType TypeId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
    public enum TransportType
    {
        Plane,
        Car,
        Taxi,
        Train,
        Bus,
        Ship
    }
}
