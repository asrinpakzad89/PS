namespace CMMSAPP.Domain.AggregatesModel.MaterialAggregate;

public class Material : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string Code { get; private set; }
    public UnitOfMeasureEnum UnitOfMeasure { get; private set; }
    public string? TechnicalSpecifications { get; private set; }

    #region Files
    private readonly List<FileResource> _FileList = new();
    public IReadOnlyCollection<FileResource> FileList => _FileList.AsReadOnly();
    #endregion
    public Material() { }

    public Material(string title, string code, UnitOfMeasureEnum unitOfMeasure, string? technicalSpecifications, string? createdBy = null)
    {
        if (!title.HasValue())
            throw new AssetDomainException("عنوان تجهیز نمی‌تواند خالی باشد.");

        if (!code.HasValue())
            throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

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
            throw new AssetDomainException("عنوان تجهیز نمی‌تواند خالی باشد.");

        if (!code.HasValue())
            throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

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
        if (file.OwnerId != this.Id || file.OwnerType != FileOwnerTypeEnum.Material)
            throw new InvalidOperationException("فابل مربوط به این انتیتی نیست.");

        _FileList.Add(file);
    }
    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);
}

