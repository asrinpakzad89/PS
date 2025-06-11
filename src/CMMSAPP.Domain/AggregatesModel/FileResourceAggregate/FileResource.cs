namespace CMMSAPP.Domain.AggregatesModel.FileResourceAggregate;

public class FileResource : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string FilePath { get; private set; }
    public string? Description { get; private set; }

    public int OwnerType { get; private set; } // Asset/ Standard Part
    public Guid OwnerId { get; private set; } //  Asset.Id/ StandardPart.Id


    protected FileResource() { }

    public FileResource(string title, string filePath, Guid entityId, FileOwnerTypeEnum ownerType, string? description = null, string? createBy = null)
    {
        if (!title.HasValue()) throw new ArgumentException("عنوان فایل نمی‌تواند خالی باشد.");
        if (!filePath.HasValue()) throw new ArgumentException("مسیر فایل نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();

        Title = title;
        FilePath = filePath;
        OwnerId = entityId;
        OwnerType = ownerType.ToInt();
        Description = description;

        SetCreationInfo(createBy);
    }

    public void Update(string title, string filePath, Guid entityId, FileOwnerTypeEnum ownerType, string? description = null, string? modifyBy = null)
    {
        if (!title.HasValue()) throw new ArgumentException("عنوان فایل نمی‌تواند خالی باشد.");
        if (!filePath.HasValue()) throw new ArgumentException("مسیر فایل نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();

        Title = title;
        FilePath = filePath;
        OwnerId = entityId;
        OwnerType = ownerType.ToInt();
        Description = description;

        SetModificationInfo(modifyBy);
    }
    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);

}

