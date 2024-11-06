using ClickCart.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.IRepositiers
{
    public interface IGeniericRepositery<T> where T:class
    {
        public Task<IEnumerable<T>>GetAll(Expression<Func<T,bool>>filter,int page_size,int page_number,string IncludeProprity=null);
        public Task<T>  GetById(int id);
        public Task Create(T model);
        public void Update(T model);
        public void Delete(int id);

    }
}
