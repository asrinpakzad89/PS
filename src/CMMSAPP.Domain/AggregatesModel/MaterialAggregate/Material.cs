namespace CMMSAPP.Domain.AggregatesModel.MaterialAggregate;

public class Material : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string Code { get; private set; }
    public UnitOfMeasureEnum UnitOfMeasure { get; private set; }
    public string? TechnicalSpecifications { get; private set; }

    #region Collection
    private readonly List<FileResource> _files = new();
    public IReadOnlyCollection<FileResource> Files => _files.AsReadOnly();
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
    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);
}

