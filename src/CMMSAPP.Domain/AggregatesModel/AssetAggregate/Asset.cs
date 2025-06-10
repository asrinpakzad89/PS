namespace CMMSAPP.Domain.AggregatesModel.AssetAggregate;

public class Asset : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string Code { get; private set; }
    public int Quantity { get; private set; }
    public AssetTypeEnum AssetType { get; private set; } // Assembly or Part

    //public decimal Cost { get; private set; }
    //public decimal TotalCost { get; private set; }

    public Guid CategoryId { get; private set; }
    public AssetCategory Category { get; private set; }

    public Guid? ParentId { get; private set; }
    public Asset? Parent { get; private set; }

    private readonly List<Asset> _children = new();
    public IReadOnlyCollection<Asset> Children => _children.AsReadOnly();


    public Guid AssetIdentityId { get; private set; }
    public AssetIdentity AssetIdentity { get; private set; }

    //public Guid SpecificationId { get; private set; }
    //public AssetSpecification Specification { get; private set; }

    //private readonly List<AssetFeature> _features = new();
    //public IReadOnlyCollection<AssetFeature> Features => _features.AsReadOnly();

    #region Dimensions
    private readonly List<AssetDimension> _DimensionList = new();
    public IReadOnlyCollection<AssetDimension> DimensionList => _DimensionList.AsReadOnly();
    #endregion

    #region Files
    private readonly List<AssetFiles> _FileList = new();
    public IReadOnlyCollection<AssetFiles> FileList => _FileList.AsReadOnly();
    #endregion


    #region Location
    private readonly List<AssetRelocation> _locationHistory = new();
    public IReadOnlyCollection<AssetRelocation> LocationHistory => _locationHistory.AsReadOnly();

    public AssetRelocation CurrentLocations =>
    _locationHistory.OrderByDescending(s => s.Date).FirstOrDefault();
    #endregion

    #region Status
    private readonly List<AssetStatus> _statusHistory = new();
    public IReadOnlyCollection<AssetStatus> StatusHistory => _statusHistory.AsReadOnly();

    public AssetStatusTypeEnum CurrentStatus =>
    _statusHistory.OrderByDescending(s => s.Date).FirstOrDefault()?.Status ?? AssetStatusTypeEnum.Active;
    #endregion


    //private readonly List<AssetService> _services = new();
    //public IReadOnlyCollection<AssetService> Services => _services.AsReadOnly();


    protected Asset() { }

    public Asset(string title, string code, decimal cost, decimal totalCost, Guid categoryId, Guid locationId,
        Guid specificationId, AssetIdentity AssetIdentityId, Guid AssetLevelId, DateTime statusDate, string? createdBy = null)
    {
        Id = Guid.NewGuid();
        Title = title;
        Code = code;
        CategoryId = categoryId;
        AssetIdentityId = AssetIdentityId;
        AssetLevelId = AssetLevelId;
        AddStatus(AssetStatusTypeEnum.Active, statusDate, "وضعیت اولیه", createdBy);
        SetCreationInfo(createdBy);
    }
    public void SetParent(Asset parent)
    {
        if (parent.Id == Id)
            throw new AssetDomainException("تجهیز نمی‌تواند والد خودش باشد.");

        if (IsCircularParenting(parent))
            throw new AssetDomainException("شناسه والد به صورت حلقه‌ای تکرار شده است.");

        Parent = parent;
        ParentId = parent.Id;
        parent._children.Add(this);
        SetModificationInfo(null);
    }

    private bool IsCircularParenting(Asset node)
    {
        var current = node;
        while (current != null)
        {
            if (current.Id == Id) return true;
            current = current.Parent;
        }
        return false;
    }

    public void AddStatus(AssetStatusTypeEnum newStatus, DateTime neweDate, string? newDescription, string? createdBy = null)
    {
        if (CurrentStatus == newStatus) return;

        _statusHistory.Add(new AssetStatus(Id, newStatus, neweDate, newDescription, createdBy));
        SetModificationInfo(createdBy);
    }

    //public void AddFeature(FeatureType type, decimal value)
    //{
    //    _features.Add(new AssetFeature(Id, type.Id, value));
    //}
    //public void AddFile(string fileName, string filePath, FileTypeEnum fileType, string? description, string? createdBy = null)
    //{
    //    _files.Add(new AssetFile(Id, fileName, filePath, fileType, description, createdBy));
    //    SetModificationInfo(createdBy);
    //}
    //public void Relocate(Guid newLocationId, string? description, string? createdBy = null)
    //{
    //    var relocation = new AssetRelocation(Id, InstallationLocationId, newLocationId, description ?? "Relocated", createdBy);
    //    _services.Add(new AssetService(Id, DateTime.UtcNow, ServiceTypeEnum.Corrective, "Relocation registered", createdBy));
    //    InstallationLocationId = newLocationId;
    //    SetModificationInfo(createdBy);
    //}

    //public void UpdateSpecification(AssetSpecification newSpec, string? modifiedBy = null)
    //{
    //    Specification = newSpec;
    //    SetModificationInfo(modifiedBy);
    //}

    //public void UpdateFeatures(IEnumerable<(FeatureType featureType, decimal value)> newFeatures)
    //{
    //    var updates = newFeatures.ToList();

    //    _features.RemoveAll(existing =>
    //        !updates.Any(f => f.featureType.Id == existing.FeatureTypeId)
    //    );

    //    foreach (var (featureType, value) in updates)
    //    {
    //        var existing = _features.FirstOrDefault(f => f.FeatureTypeId == featureType.Id);

    //        if (existing == null)
    //        {
    //            // Add new feature
    //            _features.Add(new AssetFeature(Id, featureType.Id, value));
    //        }
    //        else if (existing.Value != value)
    //        {
    //            // Update existing feature
    //            existing.UpdateValue(value);
    //        }
    //    }
    //}

    public void UpdateBasicInfo(string title, string code, decimal cost, decimal totalCost, Guid categoryId, Guid locationId, Guid assetIdentityId, string? modifiedBy = null)
    {
        Title = title;
        Code = code;
        //Cost = cost;
        //TotalCost = totalCost;
        CategoryId = categoryId;
        AssetIdentityId = assetIdentityId;
        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);
}
