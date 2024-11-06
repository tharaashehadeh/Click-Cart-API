using AutoMapper;
using ClickCart.Core.Entites;
using ClickCart.Core.Entites.DTO;

namespace ClickCart.API.MppingProfile
{
    public class MappingProfile :Profile 
    {
        public MappingProfile()
        {//mapping
            CreateMap<Productsss, ProductDTO>()
                .ForMember(To => To.Category_Name, from => from.MapFrom(x => x.Category != null ? x.Category.Name : null));
            CreateMap<Users, UsersDTO>();
        }
    }
}
