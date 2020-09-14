using AutoMapper;
using provide.DTOs;
using provide.Model.NChain;

namespace provide.Profiles
{
    public class BusinessObjectProfile : Profile
    {
        public BusinessObjectProfile()
        {
            CreateMap<ConnectedEntity, BusinessObjectDto>();
            CreateMap<BusinessObjectDto, ConnectedEntity>();
        }
    }
}
