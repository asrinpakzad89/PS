namespace CMMSAPP.Domain.AggregatesModel.LevelAggregate;

public class Level : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string? Code { get; private set; }

    public Guid? ParentId { get; private set; }
    public Level? Parent { get; private set; }

    private readonly List<Level> _children = new();
    public IReadOnlyCollection<Level> Children => _children.AsReadOnly();

    public string? Description { get; private set; }

    protected Level() { }

    public Level(string title, string? code, string? description, Level? parent = null, string? createdBy = null)
    {
        if (!title.HasValue())
            throw new AssetDomainException("عنوان نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();
        Title = title;
        Code = code;
        Description = description;

        if (parent != null)
            SetParent(parent);

        SetCreationInfo(createdBy);
    }

    public void SetParent(Level parent)
    {
        if (parent.Id == this.Id)
            throw new AssetDomainException("سطح انتخابی نمی‌تواند والد خودش باشد.");
        if (IsCircularParenting(parent))
            throw new AssetDomainException("شناسه والد به صورت حلقه‌ای تکرار شده است.");

        Parent = parent;
        ParentId = parent.Id;
        parent._children.Add(this);
        SetModificationInfo(null);
    }

    private bool IsCircularParenting(Level potentialParent)
    {
        var current = potentialParent;
        while (current != null)
        {
            if (current.Id == this.Id)
                return true;
            current = current.Parent;
        }
        return false;
    }
    public void Update(string newTitle, string? newCode, string? newDescription, string? modifiedBy = null)
    {
        if (!newTitle.HasValue())
            throw new AssetDomainException("به‌روزرسانی ناموفق بود. عنوان نمی‌تواند خالی باشد.");

        Title = newTitle;
        Code = newCode;
        Description = newDescription;

        SetModificationInfo(modifiedBy);
    }
    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);

}
