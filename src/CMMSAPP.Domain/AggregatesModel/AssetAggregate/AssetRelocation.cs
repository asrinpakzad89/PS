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

    public AssetRelocation(Guid assetId, Guid fromLocationId, Guid toLocationId, string? description, string? createdBy = null)
    {
        AssetId = assetId;
        FromLocationId = fromLocationId;
        ToLocationId = toLocationId;
        Date = DateTime.UtcNow;
        Description = description;
        SetCreationInfo(createdBy);
    }
}
