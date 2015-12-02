using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTravel.Infrastructure.Entities
{
    public class NotesInObject
    {
        public Guid Id { get; set; }
        public Note NoteId { get; set; }
        public Transport TransportId { get; set; }
        public Apartment ApartmentId { get; set; }
        public Place PlaceId { get; set; }
    }
}
