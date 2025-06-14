namespace AnimalIdentifier.Domain.SeedWork;

public abstract class Entity
{
    private int? _requestedHashCode;
    private Guid _id;

    public virtual Guid Id
    {
        get => _id;
        protected set => _id = value;
    }

    public bool IsDelete { get; protected set; }
    public bool IsDisable { get; protected set; }

    public DateTime CreatedAt { get; protected set; }
    public string? CreatedBy { get; protected set; }

    public DateTime? ModifiedAt { get; protected set; }
    public string? ModifiedBy { get; protected set; }

    private List<INotification>? _domainEvents;
    public IReadOnlyCollection<INotification>? DomainEvents => _domainEvents?.AsReadOnly();

    protected Entity()
    {
        _id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    #region Domain Events

    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents ??= new List<INotification>();
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    #endregion

    #region Audit Info

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

    #endregion

    #region Status Control

    public void SoftDelete(string? userName = null)
    {
        IsDelete = true;
        SetModificationInfo(userName);
    }

    public void Disable(string? userName = null)
    {
        IsDisable = true;
        SetModificationInfo(userName);
    }

    public void Enable(string? userName = null)
    {
        IsDisable = false;
        SetModificationInfo(userName);
    }

    #endregion

    #region Equality (مقایسه موجودیت‌ها)

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not Entity other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        if (Id == Guid.Empty || other.Id == Guid.Empty)
            return false;

        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        if (!_requestedHashCode.HasValue)
            _requestedHashCode = Id.GetHashCode() ^ 31;

        return _requestedHashCode.Value;
    }

    public static bool operator ==(Entity? left, Entity? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity? left, Entity? right)
    {
        return !(left == right);
    }

    #endregion
}