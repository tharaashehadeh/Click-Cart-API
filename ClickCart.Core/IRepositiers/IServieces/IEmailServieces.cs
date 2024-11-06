using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.IRepositiers.IServieces
{
    public interface IEmailServieces
    {
        Task SendEmailAsync(string toemail,string subject,string message);
    }
}
