using CMMSAPP.Domain.AggregatesModel.AssetGroupAggregate;

namespace CMMSAPP.Domain.AggregatesModel.AssetCategoryAggregate;

public class AssetCategory : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string Code { get; private set; }
    public Guid AssetGroupId { get; private set; }
    public AssetGroup AssetGroup { get; private set; }

    #region Asset
    private readonly List<Asset> _AssetList = new();
    public IReadOnlyCollection<Asset> AssetList => _AssetList.AsReadOnly();
    #endregion

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

        Title = name;
        Code = code;
        AssetGroupId = groupId;
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


        Title = name;
        Code = code;
        AssetGroupId = groupId;
        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void DisableCategory(string? modifiedBy = null) => Disable(modifiedBy);
    public void EnableCategory(string? modifiedBy = null) => Enable(modifiedBy);
}

