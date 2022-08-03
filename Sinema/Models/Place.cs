using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinema.Models
{
    public class Place
    {

        public Place()
        {
            Tickets = new HashSet<Ticket>();
            PlaceSessions = new HashSet<PlaceSession>();

        }
        public long Id { get; set; }
        public int RowNumber { get; set; }
        public int PlaceNumber { get; set; }
        
        public virtual ICollection<PlaceSession> PlaceSessions { get; set; }
        public virtual PlaceHall PlaceHall { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
