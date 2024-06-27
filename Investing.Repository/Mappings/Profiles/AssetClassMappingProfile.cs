using AutoMapper;

namespace Investing.Repository.Mappings.Profiles
{
    internal class AssetClassMappingProfile : Profile
    {
        public AssetClassMappingProfile()
        {
            CreateMap<Infrastructure.Entities.AssetClass, Domain.Entities.AssetClass>();
            CreateMap<Domain.Entities.AssetClass, Infrastructure.Entities.AssetClass>();
        }
    }
}
