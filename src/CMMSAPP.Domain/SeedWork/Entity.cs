namespace CMMSAPP.Domain.SeedWork;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    public bool IsDeleted { get; protected set; }
    public bool IsDisabled { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public string? CreatedBy { get; protected set; }
    public DateTime? ModifiedAt { get; protected set; }
    public string? ModifiedBy { get; protected set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    public void SetCreationInfo(string? userName)
    {
        CreatedBy = userName;
        CreatedAt = DateTime.UtcNow;
    }

    public void SetModificationInfo(string? userName)
    {
        ModifiedBy = userName;
        ModifiedAt = DateTime.UtcNow;
    }

    public void SoftDelete(string? userName = null)
    {
        IsDeleted = true;
        SetModificationInfo(userName);
    }

    public void Disable(string? userName = null)
    {
        IsDisabled = true;
        SetModificationInfo(userName);
    }

    public void Enable(string? userName = null)
    {
        IsDisabled = false;
        SetModificationInfo(userName);
    }
}