namespace CMMSAPP.Domain.AggregatesModel.AssetCategoryAggregate;

public class AssetCategory : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    public Guid GroupId { get; private set; }

    protected AssetCategory() { }

    public AssetCategory(string name, string code, Guid groupId, string? createdBy = null)
    {
        if (!name.HasValue())
            throw new AssetDomainException("عنوان دسته نمی‌تواند خالی باشد.");

        if (!code.HasValue())
            throw new AssetDomainException("کد دسته نمی‌تواند خالی باشد.");

        if (groupId == null)
            throw new AssetDomainException("گروه تجهیز نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();

        Name = name;
        Code = code;
        GroupId = groupId;
        SetCreationInfo(createdBy);
    }

    public void Update(string name, string code, Guid groupId, string? modifiedBy = null)
    {
        if (!name.HasValue())
            throw new AssetDomainException("عنوان دسته نمی‌تواند خالی باشد.");

        if (!code.HasValue())
            throw new AssetDomainException("کد دسته نمی‌تواند خالی باشد.");

        if (groupId == null)
            throw new AssetDomainException("گروه تجهیز نمی‌تواند خالی باشد.");


        Name = name;
        Code = code;
        GroupId = groupId;
        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void DisableCategory(string? modifiedBy = null) => Disable(modifiedBy);
    public void EnableCategory(string? modifiedBy = null) => Enable(modifiedBy);
}

