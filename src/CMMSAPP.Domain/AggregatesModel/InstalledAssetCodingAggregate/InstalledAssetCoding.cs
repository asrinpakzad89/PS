namespace CMMSAPP.Domain.AggregatesModel.InstalledAssetCodingAggregate;

public class InstalledAssetCode : Entity, IAggregateRoot
{
    public Guid AssertCodingId { get; private set; }
    public AssertCoding AssertCoding { get; private set; }

    public Guid LocationId { get; private set; }
    public Location Location { get; private set; }

    public int Number { get; private set; }

    public string Code { get; private set; }

    public string? Description { get; private set; }

    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public InstalledAssetCode() { }

    public InstalledAssetCode(Guid assertCodingId, Guid locationId, int number, string code, string? description = null, string? createdBy = null)
    {
        if (assertCodingId == null) throw new AssetDomainException("کدینگ دارایی نمی‌تواند خالی باشد.");
        if (locationId == null) throw new AssetDomainException("مکان استقرار نمی‌تواند خالی باشد.");
        if (number <= 0) throw new AssetDomainException("مقدار شمارنده تجهیز مستقر باید بیشتر از صفر باشد.");

        Id = Guid.NewGuid();

        AssertCodingId = assertCodingId;
        LocationId = locationId;
        Number = number;
        Description = description;
        Code = code;
        //Code = GenerateCode(assetCoding.Code, location.Code, number);

        SetCreationInfo(createdBy);
    }

    public void Update(Guid assertCodingId, Guid locationId, int number, string code, string? description = null, string? modifiedBy = null)
    {
        if (assertCodingId == null) throw new AssetDomainException("کدینگ دارایی نمی‌تواند خالی باشد.");
        if (locationId == null) throw new AssetDomainException("مکان استقرار نمی‌تواند خالی باشد.");
        if (number <= 0) throw new AssetDomainException("مقدار شمارنده تجهیز مستقر باید بیشتر از صفر باشد.");

        Id = Guid.NewGuid();

        AssertCodingId = assertCodingId;
        LocationId = locationId;
        Number = number;
        Description = description;
        Code = code;
        //Code = GenerateCode(assetCoding.Code, location.Code, number);

        SetModificationInfo(modifiedBy);
    }

    private string GenerateCode(string assetCode, string locationCode, int seq)
    {
        return $"{assetCode}.{locationCode}.{seq.ToString("D4")}";
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);

}
