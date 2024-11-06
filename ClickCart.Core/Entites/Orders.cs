using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.Entites
{
    public class Orders
    {
        public int Id { get; set; }
        // [ForeignKey(nameof(User))]
        //public int UserId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual Users? User { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new HashSet<OrderDetails>();//عشان ما يكرر في داتا لما يجيبها 



    }
}
