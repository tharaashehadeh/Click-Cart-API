using ClickCart.Core.Entites;
using ClickCart.Core.IRepositiers;
using ClickCart.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Infrastructure.Repositiers
{
    public class ProductsssRepositery :GeniericRepositery<Productsss>, IProductsssRepository
    {
        private readonly AppDbContext dbContext;

        public ProductsssRepositery(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Productsss>> GetAllProductByCategoryId(int Cat_Id)
        {
            //Eager loading
            ///في طلب واحد بجيب فيها الثنين
            ///على مرة وحدة
           /*    var products = (IEnumerable<Productsss>)await dbContext.Productsss.Include(x => x.Category)
                 .Where(c => c.Category_Id == Cat_Id)
                 .ToListAsync();
                   return products;*/


            ////[Explict Loading]
            ////
          
            ///بتنفذ على توووو ريكوست على مرتين بتنفذ
          /* var products = await dbContext.Productsss
                           .Where(c => c.Category_Id == Cat_Id)
                           .ToListAsync();
            foreach (var product in products)
            {
              await  dbContext.Entry(product).Reference(r => r.Category).LoadAsync();
            }
            return products;*/

            ///LazyLoading
            ///عرف من المابنغ نفس explist
            ///ما بكتبله اني محتاج ريلاتيد داتا
            var products = await dbContext.Productsss
                          .Where(c => c.Category_Id == Cat_Id)
                          .ToListAsync();
                           return products;
        }

        public void GetProductFilter()
        {
            throw new NotImplementedException();
        }
    }
}
////pagintion 
///عشان اقلل الداتا تاعتي 
///pagesize
///الكمية اللي بدي اعرض فيها برودكت اللي بدها تعرض في الصفحة 
