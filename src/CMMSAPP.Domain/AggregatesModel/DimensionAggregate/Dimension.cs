namespace CMMSAPP.Domain.AggregatesModel.DimensionAggregate;
public class Dimension : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Unit { get; private set; }

    protected Dimension() { }

    public Dimension(string name, string unit)
    {
        if (!name.HasValue())
            throw new AssetDomainException("عنوان نمی‌تواند خالی باشد.");

        if (unit.HasValue())
            throw new AssetDomainException("واحد اندازه‌گیری نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();
        Name = name;
        Unit = unit;
    }

    public void Update(string name, string unit)
    {
        if (!name.HasValue())
            throw new AssetDomainException("عنوان نمی‌تواند خالی باشد.");

        if (unit.HasValue())
            throw new AssetDomainException("واحد اندازه‌گیری نمی‌تواند خالی باشد.");

        Name = name;
        Unit = unit;
    }
}

