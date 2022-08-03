using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinema.ViewModels
{
    public class PlaceViewModel
    {
        public long Id { get; set; }
        public int Row { get; set; }
        public int PlaceNum { get; set; }
        public bool Availability { get; set; }
        public int Cost { get; set; }
    }
}
