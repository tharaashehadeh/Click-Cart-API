using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.Entites.DTO
{
    public class ProductDTOCreate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal price { get; set; }
        public string? Image { get; set; }
        public int Category_Id { get; set; } 
    }
}
