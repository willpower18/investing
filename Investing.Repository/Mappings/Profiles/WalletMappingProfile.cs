using AutoMapper;

namespace Investing.Repository.Mappings.Profiles
{
    internal class WalletMappingProfile : Profile
    {
        public WalletMappingProfile()
        {
            CreateMap<Infrastructure.Entities.Wallet, Domain.Entities.Wallet>();
            CreateMap<Domain.Entities.Wallet, Infrastructure.Entities.Wallet>();
        }
    }
}
