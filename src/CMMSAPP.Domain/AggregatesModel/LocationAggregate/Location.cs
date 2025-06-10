namespace CMMSAPP.Domain.AggregatesModel.LocationAggregate;

public class Location : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Code { get; private set; }

    public Guid? ParentId { get; private set; }
    public Location? Parent { get; private set; }

    private readonly List<Location> _children = new();
    public IReadOnlyCollection<Location> Children => _children.AsReadOnly();

    protected Location() { }

    public Location(string name, string code, Guid? parentId, string? createdBy = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new AssetDomainException("عنوان مکان نمی‌تواند خالی باشد. لطفاً یک عنوان معتبر وارد کنید.");

        if (string.IsNullOrWhiteSpace(code))
            throw new AssetDomainException("کد مکان نمی‌تواند خالی باشد. لطفاً یک کد معتبر وارد کنید.");

        Name = name;
        Code = code;
        parentId = parentId;
        SetCreationInfo(createdBy);
    }

    public void Update(string name, string code, Guid? parentId, string? modifiedBy = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new AssetDomainException("به‌روزرسانی ناموفق بود. عنوان مکان نمی‌تواند خالی باشد.");

        if (string.IsNullOrWhiteSpace(code))
            throw new AssetDomainException("به‌روزرسانی ناموفق بود. کد مکان نمی‌تواند خالی باشد.");

        Name = name;
        Code = code;
        ParentId = parentId;
        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void DisableCategory(string? modifiedBy = null) => Disable(modifiedBy);
    public void EnableCategory(string? modifiedBy = null) => Enable(modifiedBy);
}
