using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sinema
{
    public partial class User : IdentityUser
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
        public virtual ICollection<Order> Orders { get; set; }
    }
}
