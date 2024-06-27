using AutoMapper;
using AutoMapper.Internal;
using Investing.Repository.Mappings.Profiles;
using Investing.Shared.Mappings;

namespace Investing.Repository.Configuration
{
    public class AutoMapperConfiguration : IRepositoryMapping
    {
        public IGlobalConfiguration Configuration { get; init; }

        public AutoMapperConfiguration()
        {
            Configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<AssetMappingProfile>();
                config.AddProfile<AssetClassMappingProfile>();
                config.AddProfile<SectorMappingProfile>();
                config.AddProfile<SectorConfigurationMappingProfile>();
                config.AddProfile<WalletMappingProfile>();
            });
        }

        public IMapper GetMapper()
        {
            return Configuration.CreateMapper();
        }
    }
}
