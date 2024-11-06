using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.Entites
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Orders))]
        public int Order_Id { get; set; }
        [ForeignKey(nameof(Peoductsss))]

        public int Product_Id { get; set; }
        public decimal Price { get; set; }
        public decimal Qauntity { get; set; }
        public virtual Orders? Orders { get; set; }
        public virtual Productsss? Peoductsss { get; set; }




    }
}
