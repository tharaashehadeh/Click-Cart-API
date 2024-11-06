using AutoMapper;
using ClickCart.Core.Entites;
using ClickCart.Core.Entites.DTO;
using ClickCart.Core.IRepositiers;
using ClickCart.Core.IRepositiers.IServieces;
using ClickCart.Infrastructure.Data;
using ClickCart.Servieces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Infrastructure.Repositiers
{
    public class UserRepositery : IUserRepositery
    {
        private readonly AppDbContext dbContext;
        private readonly UserManager<Users> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<Users> signInManager;
        private readonly IMapper mapper;
        private readonly ITokenServieces tokenServieces;

        public UserRepositery(AppDbContext dbContext,
            UserManager<Users> userManager,
            RoleManager<IdentityRole>roleManager,
            SignInManager<Users>signInManager,
              IMapper mapper,
              ITokenServieces tokenServieces
            )
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.tokenServieces = tokenServieces;
        }
        public bool IsUniqueUser(string Email)
        {
            var result = dbContext.Users.FirstOrDefault(x => x.Email == Email);
            return result == null;
        }

        public async Task<LoginResponesDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDTO.Email);
            var checkPassword =await signInManager.CheckPasswordSignInAsync(user, loginRequestDTO.Password, false);
            if (!checkPassword.Succeeded)
            {
                return new LoginResponesDTO()
                {
                    User=null,
                    Token="",

                };
            }
            var role = await userManager.GetRolesAsync(user);
            return new LoginResponesDTO()
            {
                User = mapper.Map<UsersDTO>(user),
                Token =await tokenServieces.CreateTokenAsync(user),
                Role=role.FirstOrDefault()
            };
        }

        public async Task<UsersDTO>Register(RegistrationRequestDTO registrationRequestDTO)
        {
            var user = new Users
            {
                Email = registrationRequestDTO.Email,//thara@gmail.com
                UserName = registrationRequestDTO.Email.Split('@')[0],//thara
                FirstName=registrationRequestDTO.Fname,
                LastName=registrationRequestDTO.Lname,
                Address=registrationRequestDTO.Address,

            };
            using(var transaction =await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var result = await userManager.CreateAsync(user, registrationRequestDTO.Password);
                    if (result.Succeeded)

                    {
                        var role = await roleManager.RoleExistsAsync(registrationRequestDTO.Role);
                        if (!role)
                        {
                            throw new Exception($"the role {registrationRequestDTO.Role} dosent's Exists.!");
                        }
                        var userRoleResult = await userManager.AddToRoleAsync(user, registrationRequestDTO.Role);
                        if (userRoleResult.Succeeded)
                        {
                          
                            var userReturn = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == registrationRequestDTO.Email);
                            await transaction.CommitAsync();
                            return mapper.Map<UsersDTO>(userReturn);
                        }
                        else
                        {
                          await  transaction.RollbackAsync();
                            throw new Exception("faild to add user to UserRole ");
                        }
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        throw new Exception("User Registrated failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            
           
        }
    }
}
