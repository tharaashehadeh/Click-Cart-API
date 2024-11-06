using ClickCart.Core.Entites.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.IRepositiers
{
    public interface IUserRepositery
    {
        Task<LoginResponesDTO>Login(LoginRequestDTO loginRequestDTO);
        Task<UsersDTO>Register(RegistrationRequestDTO registrationRequestDTO);
        bool IsUniqueUser(string Email);

    }
}
