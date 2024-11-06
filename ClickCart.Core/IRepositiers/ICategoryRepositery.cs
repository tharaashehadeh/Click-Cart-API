using ClickCart.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.IRepositiers
{
    public interface ICategoryRepositery
    {
        public IEnumerable<Categoiers> GetAllProductsss();
        public Categoiers GetById(int id);
        public void CreateProductssss(Categoiers model);
        public void UpdateProductssss(Categoiers model);
        public void DeleteProductsss(int id);

    }
}
