using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using ClickCart.Core.Entites;
using ClickCart.Core.IRepositiers;
using ClickCart.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Infrastructure.Repositiers
{
    public class GeniericRepositery<T> : IGeniericRepositery<T> where T : class
    {
        private readonly AppDbContext dbContext;

        public GeniericRepositery(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Create(T model)
        {
          await  dbContext.Set<T>().AddAsync(model);
        }

        public void Delete(int id)
        {
            dbContext.Remove(id);
        }

        public async Task<IEnumerable<T>> GetAll (Expression<Func<T,bool>>filter=null,int page_size=2,int page_number=1,string? IncludeProprity=null)
        {//مستنية من انبوت معتمدة عليه
            /*  if (typeof(T) == typeof(Productsss))
              {
                  var model = await dbContext.Productsss.Include(x => x.Category).ToListAsync();
                  return (IEnumerable<T>)model;
              }*/
            IQueryable<T>  query = dbContext.Set<T>();//products
            if (filter!=null)
            {
                query = query.Where(filter);
            }
            if(IncludeProprity !=null)
            {
                // query = query.Include(IncludeProprity);
                //IncludeProprity= "Category,Orders"
                foreach (var proprity in IncludeProprity.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries));
                query = query.Include(IncludeProprity);
            }
            if(page_size>0)
            {
                if (page_size > 10)
                {
                    page_size = 10;
                }
                query = query.Skip(page_size*(page_number-1)).Take(page_size);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T model)
        {
            dbContext.Set<T>().Update(model);
        }
    }
}
