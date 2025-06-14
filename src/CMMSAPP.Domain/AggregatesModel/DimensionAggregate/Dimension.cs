namespace CMMSAPP.Domain.AggregatesModel.DimensionAggregate;
public class Dimension : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string Unit { get; private set; }


    #region Collection
    private readonly List<AssetDimension> _assetDimensions = new();
    public IReadOnlyCollection<AssetDimension> AssetDimensions => _assetDimensions.AsReadOnly();
    #endregion
    
    protected Dimension() { }

    public Dimension(string title, string unit)
    {
        if (!title.HasValue())
            throw new AssetDomainException("عنوان نمی‌تواند خالی باشد.");

        if (unit.HasValue())
            throw new AssetDomainException("واحد اندازه‌گیری نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();
        Title = title;
        Unit = unit;
    }

    public void Update(string title, string unit)
    {
        if (!title.HasValue())
            throw new AssetDomainException("عنوان نمی‌تواند خالی باشد.");

        if (unit.HasValue())
            throw new AssetDomainException("واحد اندازه‌گیری نمی‌تواند خالی باشد.");

        Title = title;
        Unit = unit;
    }
}

