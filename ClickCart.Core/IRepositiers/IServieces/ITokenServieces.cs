using ClickCart.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.IRepositiers.IServieces
{
    public interface ITokenServieces
    {
        Task<string> CreateTokenAsync(Users users);
    }
}
