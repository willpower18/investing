using AutoMapper;

namespace Investing.Repository.Mappings.Profiles
{
    internal class SectorConfigurationMappingProfile : Profile
    {
        public SectorConfigurationMappingProfile()
        {
            CreateMap<Infrastructure.Entities.SectorConfiguration, Domain.Entities.SectorConfiguration>();
            CreateMap<Domain.Entities.SectorConfiguration, Infrastructure.Entities.SectorConfiguration>();
        }
    }
}
