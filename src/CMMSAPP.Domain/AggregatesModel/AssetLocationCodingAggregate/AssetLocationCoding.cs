namespace CMMSAPP.Domain.AggregatesModel.AssetLocationCodingAggregate;

public class AssetLocationCoding : Entity, IAggregateRoot
{
    public Guid AssetId { get; private set; }
    public Asset Asset { get; private set; }

    public Guid LocationCodingId { get; private set; }
    public LocationCoding LocationCoding { get; private set; }

    public int Number { get; private set; }

    public string Code { get; private set; }
    public string? Description { get; private set; }


    public AssetLocationCoding() { }
    public AssetLocationCoding(Guid assetId, Guid locationCodingId, string code, string description, int number = 1, string? createdBy = null)
    {
        if (assetId == null)
            throw new AssetDomainException("تجهیز موردنظر را انتخاب نمایید.");

        if (locationCodingId == null)
            throw new AssetDomainException("مکان موردنظر را وارد نمایید.");

        Id = Guid.NewGuid();
        AssetId = assetId;
        LocationCodingId = locationCodingId;
        Number = number;
        Code = code;
        Description = description;

        SetCreationInfo(createdBy);
    }
    public void Update(Guid assetId, Guid locationCodingId, string code, string description, int number = 1, string? modifyBy = null)
    {
        if (assetId == null)
            throw new AssetDomainException("تجهیز موردنظر را انتخاب نمایید.");

        if (locationCodingId == null)
            throw new AssetDomainException("مکان موردنظر را وارد نمایید.");

        Id = Guid.NewGuid();
        AssetId = assetId;
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
