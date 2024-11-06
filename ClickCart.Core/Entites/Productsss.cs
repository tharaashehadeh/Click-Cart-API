using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.Entites
{
    public class Productsss
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal price { get; set; }
        public string? Image { get; set; }

        [ForeignKey(nameof(Category))]
        public int Category_Id { get; set; }
        public virtual Categoiers? Category { get; set; }//? : do not null value 
        public virtual ICollection<OrderDetails>? OrderDetails { get; set; } = new HashSet<OrderDetails>();//عشان ما يكرر في داتا لما يجيبها 

    }
}
