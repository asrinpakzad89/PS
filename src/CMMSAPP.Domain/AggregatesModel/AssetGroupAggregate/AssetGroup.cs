namespace CMMSAPP.Domain.AggregatesModel.AssetGroupAggregate;

public class AssetGroup : Entity, IAggregateRoot
{
    public string Title { get; private set; }

    #region Asset Category
    private readonly List<AssetCategory> _AssetCategoryList = new();
    public IReadOnlyCollection<AssetCategory> AssetCategoryList => _AssetCategoryList.AsReadOnly();
    #endregion

    protected AssetGroup() { }

    public AssetGroup(string title, string? createdBy = null)
    {
        if (!title.HasValue())
            throw new AssetDomainException("عنوان گروه نمی‌تواند خالی باشد. لطفاً یک عنوان معتبر وارد کنید.");

        Id = Guid.NewGuid();
        Title = title;
        SetCreationInfo(createdBy);
    }

    public void Update(string title, string? modifiedBy = null)
    {
        if (title.HasValue())
            throw new AssetDomainException("به‌روزرسانی ناموفق بود. عنوان گروه نمی‌تواند خالی باشد.");

        Title = title;
        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
}

