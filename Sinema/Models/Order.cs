using System;
using System.Collections.Generic;

#nullable disable

namespace Sinema
{
    public partial class Order
    {
        public Order()
        {
            Tickets = new HashSet<Ticket>();
        }

        public long Id { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
