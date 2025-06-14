namespace CMMSAPP.Domain.AggregatesModel.AssetGroupAggregate;

public class Group : Entity, IAggregateRoot
{
    public string Title { get; private set; }

    #region Collection
    private readonly List<Category> _categories = new();
    public IReadOnlyCollection<Category> Categories => _categories.AsReadOnly();
    #endregion

    protected Group() { }

    public Group(string title, string? createdBy = null)
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

