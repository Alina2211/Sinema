using Sinema.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Sinema
{
    public partial class Schedule
    {
        public Schedule()
        {
            Tickets = new HashSet<Ticket>();
        }

        public long Id { get; set; }
        public long FilmId { get; set; }
        public DateTime? FilmSession { get; set; }
        public long HallId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Hall Hall { get; set; }
        public virtual ICollection<PlaceSession> PlaceSessions { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
