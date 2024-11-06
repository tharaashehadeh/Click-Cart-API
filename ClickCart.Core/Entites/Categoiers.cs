using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.Entites
{
    public class Categoiers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Productsss> Productsss { get; set; } = new HashSet<Productsss>();//عشان ما يكرر في داتا لما يجيبها 

    }
}
