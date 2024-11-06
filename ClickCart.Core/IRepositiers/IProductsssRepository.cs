using ClickCart.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.IRepositiers
{
    public interface IProductsssRepository:IGeniericRepositery<Productsss>
    {
        /*public IEnumerable<Productsss> GetAllProductsss();
        public Productsss GetById(int id);
        public void CreateProductssss(Productsss model);
        public void UpdateProductssss(Productsss model);
        public void DeleteProductsss(int id);*/
        public void GetProductFilter();
        public Task<IEnumerable<Productsss>> GetAllProductByCategoryId(int Cat_Id);
        



    }
}
