namespace Investing.Shared.DataTransferObjects
{
    public class SectorWithAssetClassDTO
    {
        public SectorWithAssetClassDTO(Guid sectorId, Guid assetClassId, string name, string description, string assetClass)
        {
            SectorId = sectorId;
            AssetClassId = assetClassId;
            Name = name;
            Description = description;
            AssetClass = assetClass;
        }

        public Guid SectorId { get; private set; }
        public Guid AssetClassId { get; private set; }        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string AssetClass { get; private set; }
    }
}
