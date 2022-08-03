using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinema.Models
{
    public class Hall
    {
        public Hall()
        {
            Places = new HashSet<PlaceHall>();
        }
        public long Id { get; set; }
        public string HallName { get; set; }

        public virtual ICollection<PlaceHall> Places { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
