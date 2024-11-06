using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.Entites.DTO
{
    public class LoginResponesDTO
    {
        public UsersDTO User { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }

    }
}
