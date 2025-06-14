using CMMSAPP.Domain.AggregatesModel.AssetTreeStructureAggregate;
using CMMSAPP.Domain.AggregatesModel.LocationAggregate;

namespace CMMSAPP.Domain.AggregatesModel.InstalledAssetCodingAggregate;

public class InstalledAssetCoding : Entity, IAggregateRoot
{
    public Guid AssetCodingId { get; private set; }
    public AssetCoding AssetCoding { get; private set; }

    public Guid LocationCodingId { get; private set; }
    public LocationCoding LocationCoding { get; private set; }

    public int Number { get; private set; }

    public string Code { get; private set; }
    public string? Description { get; private set; }


    #region Collection
    private readonly List<AssetTreeStructure> _assetTreeStructures = new();
    public IReadOnlyCollection<AssetTreeStructure> AssetTreeStructures => _assetTreeStructures.AsReadOnly();
    #endregion

    public InstalledAssetCoding() { }
    public InstalledAssetCoding(Guid assetCodingId, Guid locationCodingId, string code, string description, int number = 1, string? createdBy = null)
    {
        if (assetCodingId == null) throw new AssetDomainException("کدینگ دارایی نمی‌تواند خالی باشد.");
        if (locationCodingId == null) throw new AssetDomainException("مکان استقرار نمی‌تواند خالی باشد.");
        if (number <= 0) throw new AssetDomainException("مقدار شمارنده تجهیز مستقر باید بیشتر از صفر باشد.");

        Id = Guid.NewGuid();
        AssetCodingId = assetCodingId;
        LocationCodingId = locationCodingId;
        Number = number;
        Code = code;
        Description = description;

        SetCreationInfo(createdBy);
    }
    public void Update(Guid assetCodingId, Guid locationCodingId, string code, string description, int number = 1, string? modifyBy = null)
    {
        if (assetCodingId == null) throw new AssetDomainException("کدینگ دارایی نمی‌تواند خالی باشد.");
        if (locationCodingId == null) throw new AssetDomainException("مکان استقرار نمی‌تواند خالی باشد.");
        if (number <= 0) throw new AssetDomainException("مقدار شمارنده تجهیز مستقر باید بیشتر از صفر باشد.");

        Id = Guid.NewGuid();
        AssetCodingId = assetCodingId;
        LocationCodingId = locationCodingId;
        Number = number;
        Code = code;
        Description = description;

        SetCreationInfo(modifyBy);
    }
    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void DisableCategory(string? modifiedBy = null) => Disable(modifiedBy);
    public void EnableCategory(string? modifiedBy = null) => Enable(modifiedBy);
}
