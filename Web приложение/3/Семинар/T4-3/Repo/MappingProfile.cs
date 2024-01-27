using AutoMapper;

using T4_1.Model;
using T4_1.Model.DTO;

namespace T4_1.Repo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>(MemberList.Destination).ReverseMap();
            CreateMap<Category, CategoryDTO>(MemberList.Destination).ReverseMap();
            CreateMap<Store, StoreDTO>(MemberList.Destination).ReverseMap();
        }



    }
}
