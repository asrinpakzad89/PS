namespace CMMSAPP.Domain.AggregatesModel.LocationAggregate;

public class Location : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string Code { get; private set; }

    public Guid? ParentId { get; private set; }
    public Location? Parent { get; private set; }

    private readonly List<Location> _children = new();
    public IReadOnlyCollection<Location> Children => _children.AsReadOnly();


    #region ReLocation
    private readonly List<AssetRelocation> _relocationFrom = new();
    public IReadOnlyCollection<AssetRelocation> RelocationFrom => _relocationFrom.AsReadOnly();

    private readonly List<AssetRelocation> _relocationTo = new();
    public IReadOnlyCollection<AssetRelocation> RelocationTo => _relocationFrom.AsReadOnly();
    #endregion

    #region Installed Asset Coding
    private readonly List<InstalledAssetCoding> _installedAssetCodingList = new();
    public IReadOnlyCollection<InstalledAssetCoding> InstalledAssetCodingList => _installedAssetCodingList.AsReadOnly();
    #endregion

    #region Location Coding
    private readonly List<LocationCoding> _locationCodingList = new();
    public IReadOnlyCollection<LocationCoding> LocationCodingList => _locationCodingList.AsReadOnly();
    #endregion


    protected Location() { }

    public Location(string title, string code, Guid? parentId, string? createdBy = null)
    {
        if (!title.HasValue())
            throw new AssetDomainException("عنوان مکان نمی‌تواند خالی باشد.");

        if (!code.HasValue())
            throw new AssetDomainException("کد مکان نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();
        Title = title;
        Code = code;
        parentId = parentId;
        SetCreationInfo(createdBy);
    }

    public void Update(string title, string code, Guid? parentId, string? modifiedBy = null)
    {
        if (!title.HasValue())
            throw new AssetDomainException("عنوان مکان نمی‌تواند خالی باشد.");

        if (!code.HasValue())
            throw new AssetDomainException("کد مکان نمی‌تواند خالی باشد.");

        Title = title;
        Code = code;
        ParentId = parentId;
        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void DisableCategory(string? modifiedBy = null) => Disable(modifiedBy);
    public void EnableCategory(string? modifiedBy = null) => Enable(modifiedBy);
}
