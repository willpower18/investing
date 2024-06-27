using AutoMapper;

namespace Investing.Repository.Mappings.Profiles
{
    internal class SectorMappingProfile : Profile
    {
        public SectorMappingProfile()
        {
            CreateMap<Infrastructure.Entities.Sector, Domain.Entities.Sector>();
            CreateMap<Domain.Entities.Sector, Infrastructure.Entities.Sector>();
        }
    }
}
