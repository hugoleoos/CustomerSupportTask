using ArvatoFront.ArvatoApi.Adapter;
using ArvatoFront.Models;
using AutoMapper;

namespace ArvatoFront
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<CustomerSupportViewModel, CustomerSupportPost>();
        }
    }
}
