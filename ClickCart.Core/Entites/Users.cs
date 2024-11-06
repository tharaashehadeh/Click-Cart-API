
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.Entites
{
    public class Users: IdentityUser
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Address{ get; set; }
        public virtual ICollection<Orders> Orders { get; set; } = new HashSet<Orders>();//عشان ما يكرر في داتا لما يجيبها 




    }
}
