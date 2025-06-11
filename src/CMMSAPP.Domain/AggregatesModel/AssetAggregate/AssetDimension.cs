namespace CMMSAPP.Domain.AggregatesModel.AssetAggregate;

public class AssetDimension : Entity
{
    public Guid AssetId { get; private set; }
    public Asset Asset { get; private set; }

    public Guid DimensionId { get; private set; }
    public Dimension Dimension { get; private set; }

    public decimal Value { get; private set; }

    protected AssetDimension() { }

    public AssetDimension(Guid assetId, Guid dimensionId, decimal value, string? createdBy = null)
    {
        if (assetId == null) throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

        if (dimensionId == null) throw new AssetDomainException("کد ویژگی نمی‌تواند خالی باشد.");

        if (value == null)
            throw new AssetDomainException("مقدار ویژگی نمی‌تواند خالی باشد.");


        Id = Guid.NewGuid();
        AssetId = assetId;
        DimensionId = dimensionId;
        Value = value;
        SetCreationInfo(createdBy);
    }
    public void Update(Guid assetId, Guid dimensionId, decimal value, string? createdBy = null)
    {
        if (assetId == null) throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

        if (dimensionId == null) throw new AssetDomainException("کد ویژگی نمی‌تواند خالی باشد.");

        if (value == null)
            throw new AssetDomainException("مقدار ویژگی نمی‌تواند خالی باشد.");

        AssetId = assetId;
        DimensionId = dimensionId;
        Value = value;
        SetCreationInfo(createdBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);
}