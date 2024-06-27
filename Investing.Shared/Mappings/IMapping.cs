namespace Investing.Shared.Mappings
{
    public interface IMapping<Domain, Infrastructure>
    {
        Infrastructure MapFromDomainToInfrastructure(Domain domainEntity);

        Domain MapFromInfrastructureToDomain(Infrastructure infrastructureEntity);

        IEnumerable<Domain> MapListFromInfrastructureToDomain(IEnumerable<Infrastructure> listOfEntities);
    }
}
