using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinema.Models
{
    public class PlaceSession
    {
        public long Id { get; set; }
        public long PlaceId { get; set; }
        public long ScheduleId { get; set; }
        public int Cost { get; set; }
        public bool Availability { get; set; }

        public virtual Place Place { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
