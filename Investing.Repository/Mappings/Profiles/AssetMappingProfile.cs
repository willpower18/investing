using AutoMapper;

namespace Investing.Repository.Mappings.Profiles
{
    internal class AssetMappingProfile : Profile
    {
        public AssetMappingProfile()
        {
            CreateMap<Infrastructure.Entities.Asset, Domain.Entities.Asset>();
            CreateMap<Domain.Entities.Asset, Infrastructure.Entities.Asset>();
        }
    }
}
