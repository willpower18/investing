using AutoMapper;

namespace Investing.Repository.Mappings.Profiles
{
    internal class SectorMappingProfile : Profile
    {
        public SectorMappingProfile()
        {
            CreateMap<Infrastructure.Entities.Sector, Domain.Entities.Sector>()
                .ForMember(t => t.AssetClassName, opt => opt.Ignore());
            CreateMap<Domain.Entities.Sector, Infrastructure.Entities.Sector>()
                .ForSourceMember(s => s.AssetClassName, opt => opt.DoNotValidate());
        }
    }
}
