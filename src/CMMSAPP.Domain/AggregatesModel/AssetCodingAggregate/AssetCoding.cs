namespace CMMSAPP.Domain.AggregatesModel.AssertCodingAggregate;

public class AssetCoding : Entity, IAggregateRoot
{
    public Guid AssetId { get; private set; }
    public Asset Asset { get; private set; }

    public int FromNumber { get; private set; }
    public int ToNumber { get; private set; }

    public string Code { get; private set; }

    #region Installed Asset Coding
    private readonly List<InstalledAssetCoding> _installedAssetCodingList = new();
    public IReadOnlyCollection<InstalledAssetCoding> InstalledAssetCodingList => _installedAssetCodingList.AsReadOnly();
    #endregion

    public AssetCoding() { }
    public AssetCoding(Guid assetId, string code, int fromNumber = 1, int toNumber = 1, string? createdBy = null)
    {
        if (assetId == null)
            throw new AssetDomainException("تجهیز نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();
        AssetId = assetId;
        FromNumber = fromNumber;
        ToNumber = toNumber;
        Code = code;
        SetCreationInfo(createdBy);
    }
    public void Update(Guid assetId, string code, int fromNumber = 1, int toNumber = 1, string? createdBy = null)
    {
        if (assetId == null)
            throw new AssetDomainException("تجهیز نمی‌تواند خالی باشد.");

        AssetId = assetId;
        FromNumber = fromNumber;
        ToNumber = toNumber;
        Code = code;
        SetCreationInfo(createdBy);
    }
    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void DisableCategory(string? modifiedBy = null) => Disable(modifiedBy);
    public void EnableCategory(string? modifiedBy = null) => Enable(modifiedBy);

}
