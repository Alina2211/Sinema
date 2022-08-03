using System;
using System.Collections.Generic;

#nullable disable

namespace Sinema
{
    public partial class Film
    {
        public Film()
        {
            ActorFilms = new HashSet<ActorFilm>();
            Schedules = new HashSet<Schedule>();
        }

        public long Id { get; set; }
        public string FilmName { get; set; }
        public string Duration { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public double? Rating { get; set; }
        public string Poster { get; set; }

        public virtual ICollection<ActorFilm> ActorFilms { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
