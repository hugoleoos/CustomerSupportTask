using Arvato.Domain.Models;
using Arvato.WebAPI.Dtos;
using AutoMapper;

namespace Arvato.WebAPI
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile() 
        {
            CreateMap<CustomerSupportPost, CustomerSupport>().ReverseMap();

            CreateMap<CustomerSupportDto, CustomerSupport>().ReverseMap();

            CreateMap<CustomerSupportGet, CustomerSupport>().ReverseMap();
            
        }
    }
}
