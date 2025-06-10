namespace CMMSAPP.Domain.AggregatesModel.DimensionAggregate;
public class Dimension : Entity
{
    public string Name { get; private set; }
    public string Unit { get; private set; }

    protected Dimension() { }

    public Dimension(string name, string unit)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new AssetDomainException("عنوان نمی‌تواند خالی باشد. لطفاً یک عنوان معتبر وارد کنید.");

        if (string.IsNullOrWhiteSpace(unit))
            throw new AssetDomainException("واحد اندازه‌گیری نمی‌تواند خالی باشد. لطفاً یک مقدار صحیح وارد کنید.");

        Name = name;
        Unit = unit;
    }

    public void Update(string newName, string newUnit)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new AssetDomainException("به‌روزرسانی ناموفق بود. عنوان نمی‌تواند خالی باشد.");

        if (string.IsNullOrWhiteSpace(newUnit))
            throw new AssetDomainException("به‌روزرسانی ناموفق بود. واحد اندازه‌گیری نمی‌تواند خالی باشد.");

        Name = newName;
        Unit = newUnit;
    }
}

