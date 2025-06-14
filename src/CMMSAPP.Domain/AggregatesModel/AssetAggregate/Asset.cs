namespace CMMSAPP.Domain.AggregatesModel.AssetAggregate;

public class Asset : Entity, IAggregateRoot
{
    #region Properties

    public string Title { get; private set; }
    public string Code { get; private set; }
    public bool IsAssembly { get; private set; } // Assembly or Part

    //public int Quantity { get; private set; }
    //public decimal TotalCost { get; private set; }

    public Guid CategoryId { get; private set; }
    public Category AssetCategory { get; private set; }

    public Guid AssetIdentityId { get; private set; }
    public AssetIdentity AssetIdentity { get; private set; }

    public Guid? ParentId { get; private set; }
    public Asset? Parent { get; private set; }

    #endregion

    #region Collections

    private readonly List<Asset> _children = new();
    public IReadOnlyCollection<Asset> Children => _children.AsReadOnly();

    private readonly List<AssetDimension> _dimensions = new();
    public IReadOnlyCollection<AssetDimension> Dimensions => _dimensions.AsReadOnly();

    private readonly List<FileResource> _files = new();
    public IReadOnlyCollection<FileResource> Files => _files.AsReadOnly();

    private readonly List<AssetCoding> _codings = new();
    public IReadOnlyCollection<AssetCoding> Codings => _codings.AsReadOnly();

    private readonly List<AssetRelocation> _locationHistory = new();
    public IReadOnlyCollection<AssetRelocation> LocationHistory => _locationHistory.AsReadOnly();

    private readonly List<InstalledAssetCoding> _installedlocationCodings = new();
    public IReadOnlyCollection<InstalledAssetCoding> InstalledlocationCodings => _installedlocationCodings.AsReadOnly();

    private readonly List<AssetStatus> _statusHistory = new();
    public IReadOnlyCollection<AssetStatus> StatusHistory => _statusHistory.AsReadOnly();

    #endregion

    #region Computed Properties

    public AssetRelocation? CurrentLocation =>
    _locationHistory.OrderByDescending(r => r.Date).FirstOrDefault();

    public AssetStatusTypeEnum CurrentStatus =>
    _statusHistory.OrderByDescending(s => s.Date).FirstOrDefault()?.Status ?? AssetStatusTypeEnum.Active;

    #endregion


    #region Status Management

    public void AddStatus(AssetStatusTypeEnum newStatus, DateTime date, string? description, string? createdBy = null)
    {
        if (CurrentStatus == newStatus) return;

        var status = new AssetStatus(Id, newStatus, date, description, createdBy);
        _statusHistory.Add(status);

        SetModificationInfo(createdBy);
    }

    public void RemoveStatus(Guid statusId)
    {
        var status = _statusHistory.FirstOrDefault(s => s.Id == statusId);
        if (status != null)
        {
            _statusHistory.Remove(status);
            SetModificationInfo(null);
        }
    }

    public void UpdateStatus(AssetStatus updatedStatus)
    {
        var existing = _statusHistory.FirstOrDefault(s => s.Id == updatedStatus.Id);
        if (existing != null)
        {
            _statusHistory.Remove(existing);
            _statusHistory.Add(updatedStatus);
            SetModificationInfo(null);
        }
    }
    #endregion

    #region File Management

    public void AddFile(FileResource file)
    {
        if (file == null) throw new ArgumentNullException(nameof(file));
        if (file.OwnerId != this.Id || file.OwnerType != FileOwnerTypeEnum.Asset)
            throw new InvalidOperationException("فایل متعلق به این تجهیز نیست.");

        _files.Add(file);
        SetModificationInfo(null);
    }

    public void RemoveFile(Guid fileId)
    {
        var file = _files.FirstOrDefault(f => f.Id == fileId);
        if (file != null)
        {
            _files.Remove(file);
            SetModificationInfo(null);
        }
    }

    public void UpdateFile(FileResource updatedFile)
    {
        if (updatedFile == null) throw new ArgumentNullException(nameof(updatedFile));
        var existing = _files.FirstOrDefault(f => f.Id == updatedFile.Id);
        if (existing != null)
        {
            _files.Remove(existing);
            _files.Add(updatedFile);
            SetModificationInfo(null);
        }
    }
    #endregion

    #region Constructors

    protected Asset() { }

    public Asset(
    string title,
    string code,
    decimal cost,
    decimal totalCost,
    Guid categoryId,
    Guid locationId,
    Guid specificationId,
    Guid assetIdentityId,
    Guid assetLevelId,
    DateTime statusDate,
    string? createdBy = null)
    {
        if (!title.HasValue()) throw new AssetDomainException("عنوان تجهیز نمی‌تواند خالی باشد.");
        if (!code.HasValue()) throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();
        Title = title;
        Code = code;
        CategoryId = categoryId;
        AssetIdentityId = assetIdentityId;

        AddStatus(AssetStatusTypeEnum.Active, statusDate, "وضعیت اولیه", createdBy);
        SetCreationInfo(createdBy);
    }

    #endregion

    #region Behavior Methods

    public void UpdateBasicInfo(
    string title,
    string code,
    decimal cost,
    decimal totalCost,
    Guid categoryId,
    Guid locationId,
    Guid assetIdentityId,
    string? modifiedBy = null)
    {
        if (!title.HasValue()) throw new AssetDomainException("عنوان تجهیز نمی‌تواند خالی باشد.");
        if (!code.HasValue()) throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

        Title = title;
        Code = code;
        CategoryId = categoryId;
        AssetIdentityId = assetIdentityId;

        SetModificationInfo(modifiedBy);
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

    #region Dimensions

    public void AddDimension(AssetDimension dimension)
    {
        if (dimension == null) throw new ArgumentNullException(nameof(dimension));
        _dimensions.Add(dimension);
        SetModificationInfo(null);
    }

    public void RemoveDimension(Guid dimensionId)
    {
        var dimension = _dimensions.FirstOrDefault(d => d.Id == dimensionId);
        if (dimension != null)
        {
            _dimensions.Remove(dimension);
            SetModificationInfo(null);
        }
    }

    public void UpdateDimension(AssetDimension updatedDimension)
    {
        var existing = _dimensions.FirstOrDefault(d => d.Id == updatedDimension.Id);
        if (existing != null)
        {
            _dimensions.Remove(existing);
            _dimensions.Add(updatedDimension);
            SetModificationInfo(null);
        }
    }
    #endregion
    #region Codings

    public void AddCoding(AssetCoding coding)
    {
        if (coding == null) throw new ArgumentNullException(nameof(coding));
        _codings.Add(coding);
        SetModificationInfo(null);
    }

    public void RemoveCoding(Guid codingId)
    {
        var coding = _codings.FirstOrDefault(c => c.Id == codingId);
        if (coding != null)
        {
            _codings.Remove(coding);
            SetModificationInfo(null);
        }
    }

    public void UpdateCoding(AssetCoding updatedCoding)
    {
        var existing = _codings.FirstOrDefault(c => c.Id == updatedCoding.Id);
        if (existing != null)
        {
            _codings.Remove(existing);
            _codings.Add(updatedCoding);
            SetModificationInfo(null);
        }
    }
    #endregion

    #region Relocations

    public void AddLocation(AssetRelocation relocation)
    {
        if (relocation == null) throw new ArgumentNullException(nameof(relocation));
        _locationHistory.Add(relocation);
        SetModificationInfo(null);
    }

    public void RemoveLocation(Guid relocationId)
    {
        var location = _locationHistory.FirstOrDefault(l => l.Id == relocationId);
        if (location != null)
        {
            _locationHistory.Remove(location);
            SetModificationInfo(null);
        }
    }

    public void UpdateLocation(AssetRelocation updatedRelocation)
    {
        var existing = _locationHistory.FirstOrDefault(l => l.Id == updatedRelocation.Id);
        if (existing != null)
        {
            _locationHistory.Remove(existing);
            _locationHistory.Add(updatedRelocation);
            SetModificationInfo(null);
        }
    }
    #endregion

    #region Location Codings

    public void AddInstalledLocationCoding(InstalledAssetCoding coding)
    {
        if (coding == null) throw new ArgumentNullException(nameof(coding));
        _installedlocationCodings.Add(coding);
        SetModificationInfo(null);
    }

    public void RemoveLocationCoding(Guid codingId)
    {
        var coding = _installedlocationCodings.FirstOrDefault(c => c.Id == codingId);
        if (coding != null)
        {
            _installedlocationCodings.Remove(coding);
            SetModificationInfo(null);
        }
    }

    public void UpdateLocationCoding(InstalledAssetCoding updatedCoding)
    {
        var existing = _installedlocationCodings.FirstOrDefault(c => c.Id == updatedCoding.Id);
        if (existing != null)
        {
            _installedlocationCodings.Remove(existing);
            _installedlocationCodings.Add(updatedCoding);
            SetModificationInfo(null);
        }
    }
    #endregion
   
    public void Disable(string? modifiedBy = null) => AddStatus(AssetStatusTypeEnum.Inactive, DateTime.UtcNow, "غیرفعال شد", modifiedBy);
    public void Enable(string? modifiedBy = null) => AddStatus(AssetStatusTypeEnum.Active, DateTime.UtcNow, "فعال شد", modifiedBy);

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);

    #endregion
}
