using System;
using System.Collections.Generic;

#nullable disable

namespace Sinema
{
    public partial class Actor
    {
        public Actor()
        {
            ActorFilms = new HashSet<ActorFilm>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<ActorFilm> ActorFilms { get; set; }
    }
}
