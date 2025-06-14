using CMMSAPP.Domain.AggregatesModel.AssetLocationCodingAggregate;
using CMMSAPP.Domain.AggregatesModel.LocationAggregate;

namespace CMMSAPP.Domain.AggregatesModel.LocationCodingAggregate;

public class LocationCoding : Entity, IAggregateRoot
{
    public Guid LocationId { get; private set; }
    public Location Location { get; private set; }

    public string Code { get; set; }


    #region Location Coding
    private readonly List<AssetLocationCoding> _AssetlocationCodingList = new();
    public IReadOnlyCollection<AssetLocationCoding> AssetocationCodingList => _AssetlocationCodingList.AsReadOnly();
    #endregion


    protected LocationCoding() { }

    public LocationCoding(Guid locationId, string code, string? createdBy = null)
    {
        if (LocationId == null)
            throw new AssetDomainException("مکان مورد نظر را انتخاب نمایید.");
       
        if (!code.HasValue())
            throw new AssetDomainException("کد محل استقرار را وارد نمایید.");

        Id = Guid.NewGuid();
        LocationId = locationId;
        Code = code;
        SetCreationInfo(createdBy);
    }

    public void Update(Guid locationId, string code, string? modifiedBy = null)
    {
        if (LocationId == null)
            throw new AssetDomainException("مکان مورد نظر را انتخاب نمایید.");

        if (!code.HasValue())
            throw new AssetDomainException("کد محل استقرار را وارد نمایید.");

        Id = Guid.NewGuid();
        LocationId = locationId;
        Code = code;
        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void DisableTool(string? modifiedBy = null) => Disable(modifiedBy);
    public void EnableTool(string? modifiedBy = null) => Enable(modifiedBy);
}

