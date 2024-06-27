using AutoMapper;
using AutoMapper.Internal;

namespace Investing.Shared.Mappings
{
    public interface IRepositoryMapping
    {
        IGlobalConfiguration Configuration { get; init; }

        IMapper GetMapper();
    }
}
