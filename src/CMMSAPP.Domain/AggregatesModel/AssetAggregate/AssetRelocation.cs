namespace CMMSAPP.Domain.AggregatesModel.AssetAggregate;

public class AssetRelocation : Entity
{
    public Guid AssetId { get; private set; }
    public Asset Asset { get; private set; }

    public Guid FromLocationId { get; private set; }
    public Location FromLocation { get; private set; }

    public Guid ToLocationId { get; private set; }
    public Location? ToLocation { get; private set; }

    public DateTime Date { get; private set; }
    public string? Description { get; private set; }

    protected AssetRelocation() { }

    public AssetRelocation(Guid assetId, Guid fromLocationId, Guid toLocationId, string? description, DateTime? date, string? createdBy = null)
    {
        if (assetId == null)
            throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");
        if (fromLocationId == null)
            throw new AssetDomainException("کد محل فعلی نمی‌تواند خالی باشد.");

        if (toLocationId == null)
            throw new AssetDomainException("کد محل نصب نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();
        AssetId = assetId;
        FromLocationId = fromLocationId;
        ToLocationId = toLocationId;
        Date = date ?? DateTime.UtcNow;
        Description = description;
        SetCreationInfo(createdBy);
    }
    public void Update(Guid assetId, Guid fromLocationId, Guid toLocationId, string? description, DateTime? date, string? createdBy = null)
    {
        if (assetId == null)
            throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");
        if (assetId == null)
            throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

        if (assetId == null)
            throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();
        AssetId = assetId;
        FromLocationId = fromLocationId;
        ToLocationId = toLocationId;
        Date = date ?? DateTime.UtcNow;
        Description = description;
        SetCreationInfo(createdBy);
    }
}
