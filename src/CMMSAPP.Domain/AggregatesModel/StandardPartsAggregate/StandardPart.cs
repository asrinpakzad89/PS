using CMMSAPP.Domain.AggregatesModel.FileResourceAggregate;

namespace CMMSAPP.Domain.AggregatesModel.StandardPartsAggregate;
public class StandardPart : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string Code { get; private set; }
    public UnitOfMeasureEnum UnitOfMeasure { get; private set; }
    public string? TechnicalSpecifications { get; private set; }

    #region Files
    private readonly List<FileResource> _FileList = new();
    public IReadOnlyCollection<FileResource> FileList => _FileList.AsReadOnly();
    #endregion

    public StandardPart() { }

    public StandardPart(string title, string code, UnitOfMeasureEnum unitOfMeasure, string? technicalSpecifications, string? createdBy = null)
    {
        if (!title.HasValue())
            throw new AssetDomainException("عنوان قطعه نمی‌تواند خالی باشد.");

        if (!code.HasValue())
            throw new AssetDomainException("کد قطعه نمی‌تواند خالی باشد.");

        if (unitOfMeasure == null)
            throw new AssetDomainException("واحد شمارش نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();
        Title = title;
        Code = code;
        UnitOfMeasure = unitOfMeasure;
        TechnicalSpecifications = technicalSpecifications;
        SetCreationInfo(createdBy);
    }

    public void Update(string title, string code, UnitOfMeasureEnum unitOfMeasure, string? technicalSpecifications, string? createdBy = null)
    {
        if (!title.HasValue())
            throw new AssetDomainException("عنوان قطعه نمی‌تواند خالی باشد.");

        if (!code.HasValue())
            throw new AssetDomainException("کد قطعه نمی‌تواند خالی باشد.");

        if (unitOfMeasure == null)
            throw new AssetDomainException("واحد شمارش نمی‌تواند خالی باشد.");

        Title = title;
        Code = code;
        UnitOfMeasure = unitOfMeasure;
        TechnicalSpecifications = technicalSpecifications;
        SetCreationInfo(createdBy);
    }
    public void AddFile(FileResource file)
    {
        if (file.OwnerId != this.Id || file.OwnerType != FileOwnerTypeEnum.StandardPart)
            throw new InvalidOperationException("فابل مربوط به این انتیتی نیست.");

        _FileList.Add(file);
    }
    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);

}

