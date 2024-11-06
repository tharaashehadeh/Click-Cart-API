using ClickCart.Core.IRepositiers;
using ClickCart.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Infrastructure.Repositiers
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            productsssRepository = new ProductsssRepositery(dbContext);
        }
        public IProductsssRepository productsssRepository { get ; set ; }
        public ICategoryRepositery categoryRepositery { get; set; }

        public async Task <int> save()
        
        =>await dbContext.SaveChangesAsync();
        
    }
}
