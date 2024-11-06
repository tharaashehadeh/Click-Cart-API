using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.IRepositiers
{
    public interface IUnitOfWork<T> where T: class
    {
        public IProductsssRepository productsssRepository { get; set; }
        public ICategoryRepositery categoryRepositery { get; set; }
        public Task<int> save();
    }
}
