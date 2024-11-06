using ClickCart.Core.Entites;
using ClickCart.Core.IRepositiers;
using ClickCart.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClickCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IUnitOfWork<Categoiers> unitOfWork;
       // private readonly ICategoryRepositery geniericRepositery;
      //  private readonly IGeniericRepositery<Categoiers> geniericRepositery;

        public CategoryController(AppDbContext dbContext,IUnitOfWork<Categoiers> unitOfWork)
        {
            this.dbContext = dbContext;
            this.unitOfWork = unitOfWork;
           // geniericRepositery = geniericRepositery;
            //  this.geniericRepositery = geniericRepositery;
        }

    }
}
