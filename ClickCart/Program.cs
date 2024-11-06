
using AutoMapper;
using ClickCart.API.MppingProfile;
using ClickCart.Core.Entites;
using ClickCart.Core.Entites.DTO;
using ClickCart.Core.IRepositiers;
using ClickCart.Core.IRepositiers.IServieces;
using ClickCart.Infrastructure.Data;
using ClickCart.Infrastructure.Repositiers;
using ClickCart.Servieces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ClickCart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.CacheProfiles.Add("defaultCashe", new CacheProfile()
                {

                    Duration = 30,
                    Location = ResponseCacheLocation.Any
                });
            });
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection2")).UseLazyLoadingProxies(false);

            });
            builder.Services.AddScoped(typeof(IProductsssRepository), typeof(ProductsssRepositery));
            builder.Services.AddScoped(typeof(IGeniericRepositery<>), typeof(GeniericRepositery<>));
            builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<ITokenServieces, TokenServieces>();
            builder.Services.AddTransient<IEmailServieces, EmailServieces>();
            builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(1);
            });
            var key = builder.Configuration.GetValue<string>("ApiSetting:SecretKey");
           
            builder.Services.AddScoped(typeof(IUserRepositery), typeof(UserRepositery));
            // builder.Services.AddScoped(typeof(UserManager<Users>));
            // builder.Services.AddScoped(typeof(RoleManager<IdentityRole>));
            // builder.Services.AddScoped(typeof(SignInManager<IdentityRole>));
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience=false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))

                };
            });
            builder.Services.AddAuthorization();
            builder.Services.AddIdentity<Users, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<ApiBehaviorOptions>(options =>
                {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                var errors = actionContext.ModelState.Where(x => x.Value.Errors.Count() > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                var validationRespones = new ApiValidationRespones( statusCode:400) { Errors = errors };
                    return  new BadRequestObjectResult(validationRespones);
                    };
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}