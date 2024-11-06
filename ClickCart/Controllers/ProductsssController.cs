
using AutoMapper;
using ClickCart.Core.Entites;
using ClickCart.Core.Entites.DTO;
using ClickCart.Core.IRepositiers;
using ClickCart.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;

namespace ClickCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductsssController : ControllerBase
    {
        //private readonly AppDbContext dbContext;
        private readonly IUnitOfWork<Productsss> unitOfWork;
        private readonly IMapper _mapper;


        // private readonly IProductsssRepository productsssRepository;
        // private readonly IGeniericRepositery<Productsss> geniericRepositery;
        // private readonly IProductRepository productRepository;
        public ApiRespones respones;

        public ProductsssController(IUnitOfWork<Productsss> unitOfWork , IMapper mapper)
        {
           // this.dbContext = dbContext;
            this.unitOfWork = unitOfWork;
            _mapper = mapper;

            //this.productsssRepository = productsssRepository;
            //this.geniericRepositery = geniericRepositery;
            //   this.productRepository = productRepository;
            respones = new ApiRespones();
        }

        [HttpGet]
        //[ResponseCache(Duration =30,Location =ResponseCacheLocation.Any)]
        //https://localhost:7000/api/Productsss
        [ResponseCache(CacheProfileName =("defaultCashe"))]

        //لو عندي داتا بتتغير باستمرار بمنعها وظيفة الكاش
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = "admin")]
        public async Task<ActionResult<ApiRespones>> GetAllProductsss([FromQuery]string? categoryName=null,int PageSize=2,int PageNumber=1)
        {
            Expression<Func<Productsss, bool>> filter = null;
            if (!string.IsNullOrEmpty(categoryName))
            {

                filter = x => x.Category.Name.Contains(categoryName);
            }
            // var model = dbContext.Productsss;
            // var model = productRepository.GetAllProductsss();
            // var model = productsssRepository.GetAll();
            //  var model = geniericRepositery.GetAll();

            var model = await unitOfWork.productsssRepository.GetAll(IncludeProprity:"Category",page_size:PageSize,page_number:PageNumber,
                filter:filter

         );
            var check = model.Any();
            if (check)
            {
                respones.StatusCode = 200;
                respones.IsSucccess = check;
               var mappedProducts=_mapper.Map<IEnumerable<Productsss>,IEnumerable<ProductDTO>>(model);
                respones.Result = mappedProducts;
                return respones;

            }
            else
            {
                respones.Message = "not products found ";
                respones.StatusCode = 200;
                respones.IsSucccess = false;
                return respones;

            }

        }

        [HttpGet("get_id")]
       // [AllowAnonymous]
        //https://localhost:7000/api/Productsss/getbyid
        public async Task <ActionResult<ApiRespones>> GetByIdPoductsss([FromQuery]int id)
        {
            //find بتدور ب لوكل في ميموري  الاول قبل لا يروح على داتا بيس 
            //firstOrDiffult بتروح بتدور ب داتا بيس مباشرة 
            //  var model = dbContext.Productsss.Find(id);
            //var model = productsssRepository.GetById(id);
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new ApiValidationRespones(new List<string> { "Invalid ID", "Try Positive Integer" }, 400));
                }
                var model = await unitOfWork.productsssRepository.GetById(id);
                if (model == null)
                {
                    var x = model.ToString();
                    return NotFound(new ApiRespones(404, "Product Not Found"));
                }
                //var model =  geniericRepositery.GetById(id);
                return Ok(new ApiRespones(200, result: model));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiValidationRespones(new List<string> { "Internal server error", ex.Message }, StatusCodes.Status500InternalServerError));
            }
        }
        [HttpPost]
        public async Task <ActionResult<ApiRespones>> CreateProductsss(Productsss model)
        {
            // geniericRepositery.Create(model);
            // productsssRepository.Create(model);
            await  unitOfWork.productsssRepository.Create(model);
           // unitOfWork.productsssRepository.Update(model);
            //productRepository.CreateProductssss(model);
            //  dbContext.SaveChanges();///add remotly( add to database)
            unitOfWork.save();
            return Ok(model);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProductsss(Productsss model)
        {
            //geniericRepositery.Update(model);
            //productsssRepository.Update(model);
            unitOfWork.productsssRepository.Update(model);
            //dbContext.SaveChanges();///add remotly( add to database)
           await unitOfWork.save();
            return Ok(model);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProductsss(int id)
        {
            // geniericRepositery.Delete(id);
            unitOfWork.productsssRepository.Delete(id);
            // productsssRepository.Delete(id);
            // productRepository.DeleteProductsss(id);
            // dbContext.SaveChanges();///add remotly( add to database)
            await unitOfWork.save();
            return Ok();

        }
        [HttpGet("Product/{Cat_Id}")]
        public async Task<ActionResult<ApiRespones>>GetProductByCatId(int Cat_Id)
        {
            var products = await unitOfWork.productsssRepository.GetAllProductByCategoryId(Cat_Id);
            var mappedProduct=_mapper.Map<IEnumerable<Productsss>, IEnumerable<ProductDTO>>(products);
            return Ok(mappedProduct);
        }

    }
}
