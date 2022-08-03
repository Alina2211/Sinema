using System;
using System.Collections.Generic;

#nullable disable

namespace Sinema
{
    public partial class Ticket
    {
        public long TicketNumber { get; set; }
        public long ScheduleId { get; set; }
        public long PlaceId { get; set; }
        public long OrderId { get; set; }

        public virtual Models.Place Place { get; set;}
        public virtual Order Order { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
