using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinema.Models
{
    public class PlaceHall
    {
        public long Id { get; set; }
        public long PlaceId { get; set; }
        public long HallId { get; set; }
        public virtual Place Place { get; set; }
        public virtual Hall Hall { get; set; }
    }
}
