using ClickCart.Core.Entites;
using ClickCart.Core.IRepositiers.IServieces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Servieces
{
    public class TokenServieces : ITokenServieces
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<Users> userManager;
        private readonly string SecretKey;

        public TokenServieces(IConfiguration configuration, UserManager<Users> userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            SecretKey = configuration.GetSection("ApiSetting")["SecretKey"];
        }
        public async Task<string> CreateTokenAsync(Users users)
        {
            var key =Encoding.ASCII.GetBytes (SecretKey);
            var roles = await userManager.GetRolesAsync(users);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,users.FirstName)
               
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var TokenDescriptor = new SecurityTokenDescriptor
            {
              Subject= new ClaimsIdentity(claims),
              Expires=DateTime.UtcNow.AddDays(5),
              SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(TokenDescriptor);
          return  tokenHandler.WriteToken(token);
           
        }    

    }
}
