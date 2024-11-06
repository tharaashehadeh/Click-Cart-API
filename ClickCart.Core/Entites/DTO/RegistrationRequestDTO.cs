using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.Entites.DTO
{
    public class RegistrationRequestDTO
    {
        // public string UserName { get; set; }
        public string Email { get; set; }

        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}
