using System;
using System.Collections.Generic;

#nullable disable

namespace Sinema
{
    public partial class ActorFilm
    {
        public long RowId { get; set; }
        public long ActorId { get; set; }
        public long FilmId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Film Film { get; set; }
    }
}
