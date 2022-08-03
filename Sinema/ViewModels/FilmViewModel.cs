using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinema.ViewModels
{
    public class FilmViewModel
    {
        public long FilmId { get; set; }
        public string FilmName { get; set; }
        public string Duration { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public double? Rating { get; set; }
        public string Poster { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Schedule> Sessions { get; set; }
    }
}
