namespace CMMSAPP.Domain.AggregatesModel.AssertCodingAggregate;

public class InstalledAssetCode : Entity
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

    public InstalledAssetCode(AssertCoding assetCoding, Location location, int number, string code, string? description = null, string? createdBy = null)
    {
        if (assetCoding == null) throw new AssetDomainException("کدینگ دارایی نمی‌تواند خالی باشد.");
        if (location == null) throw new AssetDomainException("مکان استقرار نمی‌تواند خالی باشد.");
        if (number <= 0) throw new AssetDomainException("شماره تجهیز مستقر باید بیشتر از صفر باشد.");

        AssertCodingId = assetCoding.Id;
        LocationId = location.Id;
        AssertCoding = assetCoding;
        Location = location;
        Number = number;
        Description = description;
        Code = code;
        //Code = GenerateCode(assetCoding.Code, location.Code, number);

        SetCreationInfo(createdBy);
    }

    public void Update(AssertCoding assetCoding, Location location, int number, string code, string? description = null, string? modifiedBy = null)
    {
        if (assetCoding == null) throw new AssetDomainException("کدینگ دارایی نمی‌تواند خالی باشد.");
        if (location == null) throw new AssetDomainException("مکان استقرار نمی‌تواند خالی باشد.");
        if (number <= 0) throw new AssetDomainException("شماره تجهیز مستقر باید بیشتر از صفر باشد.");

        AssertCodingId = assetCoding.Id;
        LocationId = location.Id;
        AssertCoding = assetCoding;
        Number = number;
        Description = description;
        Code = code;
        //Code = GenerateCode(AssertCoding.Code, Location.Code, number);

        SetModificationInfo(modifiedBy); // جایگزین با نام کاربری یا یوزر آی‌دی اگر دارید
    }

    private string GenerateCode(string assetCode, string locationCode, int seq)
    {
        return $"{assetCode}.{locationCode}.{seq.ToString("D4")}";
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);

}
