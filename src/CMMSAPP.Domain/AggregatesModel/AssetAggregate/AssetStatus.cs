namespace CMMSAPP.Domain.AggregatesModel.AssetAggregate;

public class AssetStatus : Entity
{
    public Guid AssetId { get; private set; }
    public Asset Asset { get; private set; }

    public AssetStatusTypeEnum Status { get; private set; }
    public string? Description { get; private set; }

    public DateTime Date { get; set; }

    public AssetStatus() { }
    public AssetStatus(Guid assetId, AssetStatusTypeEnum status, DateTime date, string? description = null, string? createdBy = null)
    {
        if (assetId == null) throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

        if (status == null) throw new AssetDomainException("نوع وضعیت نمی‌تواند خالی باشد.");

        if (Date == null) throw new AssetDomainException("هیچ فایلی انتخاب نشده است.");

        AssetId = assetId;
        Status = status;
        Date = date;
        Description = description;

        SetCreationInfo(createdBy);
    }
    public void Update(Guid assetId, AssetStatusTypeEnum status, DateTime date, string? description = null, string? modifiedBy = null)
    {
        if (assetId == null) throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

        if (status == null) throw new AssetDomainException("نوع وضعیت نمی‌تواند خالی باشد.");

        if (Date == null) throw new AssetDomainException("هیچ فایلی انتخاب نشده است.");

        AssetId = assetId;
        Status = status;
        Date = date;
        Description = description;
        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);
}
