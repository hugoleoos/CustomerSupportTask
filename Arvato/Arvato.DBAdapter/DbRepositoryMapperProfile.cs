using Arvato.Domain.Models;
using AutoMapper;

namespace Arvato.DBAdapter
{
    public class DbRepositoryMapperProfile : Profile
    {
        public DbRepositoryMapperProfile() 
        {
            CreateMap<CustomerSupport, Entities.CustomerSupport>();

            CreateMap<Entities.CustomerSupport, CustomerSupport>();
        }    
    }
}
