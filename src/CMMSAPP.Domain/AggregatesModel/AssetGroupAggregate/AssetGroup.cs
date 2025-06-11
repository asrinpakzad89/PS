namespace CMMSAPP.Domain.AggregatesModel.AssetGroupAggregate;

public class AssetGroup : Entity, IAggregateRoot
{
    public string Name { get; private set; }

    protected AssetGroup() { }

    public AssetGroup(string name, string? createdBy = null)
    {
        if (!name.HasValue())
            throw new AssetDomainException("عنوان گروه نمی‌تواند خالی باشد. لطفاً یک عنوان معتبر وارد کنید.");

        Id = Guid.NewGuid();
        Name = name;
        SetCreationInfo(createdBy);
    }

    public void Update(string name, string? modifiedBy = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new AssetDomainException("به‌روزرسانی ناموفق بود. عنوان گروه نمی‌تواند خالی باشد.");

        Name = name;
        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
}

