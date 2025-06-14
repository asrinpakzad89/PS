using CMMSAPP.Common.Utilities;
using CMMSAPP.Domain.AggregatesModel.AssertCodingAggregate;
using CMMSAPP.Domain.AggregatesModel.AssetLocationCodingAggregate;
using CMMSAPP.Domain.AggregatesModel.FileResourceAggregate;
using CMMSAPP.Domain.AggregatesModel.ToolsAggregate;

namespace CMMSAPP.Domain.AggregatesModel.AssetAggregate;

public class Asset : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string Code { get; private set; }
    public bool IsAssembly { get; private set; } // Assembly or Part

    //public int Quantity { get; private set; }
    //public decimal TotalCost { get; private set; }

    public Guid CategoryId { get; private set; }
    public AssetCategory AssetCategory { get; private set; }

    #region Parent & Children
    public Guid? ParentId { get; private set; }
    public Asset? Parent { get; private set; }

    private readonly List<Asset> _children = new();
    public IReadOnlyCollection<Asset> Children => _children.AsReadOnly();
    #endregion

    #region Identity
    public Guid AssetIdentityId { get; private set; }
    public AssetIdentity AssetIdentity { get; private set; }
    #endregion

    #region Dimensions
    private readonly List<AssetDimension> _DimensionList = new();
    public IReadOnlyCollection<AssetDimension> DimensionList => _DimensionList.AsReadOnly();
    #endregion

    #region Files
    private readonly List<FileResource> _FileList = new();
    public IReadOnlyCollection<FileResource> FileList => _FileList.AsReadOnly();
    #endregion

    #region AssetCoding
    private readonly List<AssetCoding> _AssetCodingList = new();
    public IReadOnlyCollection<AssetCoding> AssetCodingList => _AssetCodingList.AsReadOnly();
    #endregion

    #region Location History & Current Location
    private readonly List<AssetRelocation> _locationHistory = new();
    public IReadOnlyCollection<AssetRelocation> LocationHistory => _locationHistory.AsReadOnly();

    public AssetRelocation CurrentLocation =>
    _locationHistory.OrderByDescending(s => s.Date).FirstOrDefault();
    #endregion

    #region Location Coding
    private readonly List<AssetLocationCoding> _AssetlocationCodingList = new();
    public IReadOnlyCollection<AssetLocationCoding> AssetocationCodingList => _AssetlocationCodingList.AsReadOnly();
    #endregion

    #region Status History & Current Status
    private readonly List<AssetStatus> _statusHistory = new();
    public IReadOnlyCollection<AssetStatus> StatusHistory => _statusHistory.AsReadOnly();

    public AssetStatusTypeEnum CurrentStatus =>
    _statusHistory.OrderByDescending(s => s.Date).FirstOrDefault()?.Status ?? AssetStatusTypeEnum.Active;
    #endregion

    //#region Tools
    //private readonly List<AssetTool> _ToolsList = new();
    //public IReadOnlyCollection<AssetTool> ToolList => _ToolsList.AsReadOnly();
    //#endregion

    //#region Material
    //private readonly List<AssetMaterial> _ToolsList = new();
    //public IReadOnlyCollection<AssetMaterial> ToolList => _ToolsList.AsReadOnly();
    //#endregion

    protected Asset() { }

    public Asset(string title, string code, decimal cost, decimal totalCost, Guid categoryId, Guid locationId,
        Guid specificationId, Guid assetIdentityId, Guid assetLevelId, DateTime statusDate, string? createdBy = null)
    {

        if (!title.HasValue())
            throw new AssetDomainException("عنوان تجهیز نمی‌تواند خالی باشد.");


        if (!code.HasValue())
            throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");


        Id = Guid.NewGuid();

        Title = title;
        Code = code;
        CategoryId = categoryId;
        AssetIdentityId = assetIdentityId;
        //AssetLevelId = assetLevelId;
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

    
    public void UpdateBasicInfo(string title, string code, decimal cost, decimal totalCost, Guid categoryId, Guid locationId, Guid assetIdentityId, string? modifiedBy = null)
    {
        if (!title.HasValue())
            throw new AssetDomainException("عنوان تجهیز نمی‌تواند خالی باشد.");

        if (!code.HasValue())
            throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

        Title = title;
        Code = code;
        //Cost = cost;
        //TotalCost = totalCost;
        CategoryId = categoryId;
        AssetIdentityId = assetIdentityId;
        SetModificationInfo(modifiedBy);
    }
    public void AddFile(FileResource file)
    {
        if (file.OwnerId != this.Id || file.OwnerType != FileOwnerTypeEnum.Asset)
            throw new InvalidOperationException("فابل مربوط به این انتیتی نیست.");

        _FileList.Add(file);
    }
    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);
}
