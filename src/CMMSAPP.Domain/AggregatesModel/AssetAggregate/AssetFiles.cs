using System.Xml.Linq;

namespace CMMSAPP.Domain.AggregatesModel.AssetAggregate;

public class AssetFiles : Entity
{
    public string Title { get; private set; }
    public string FilePath { get; private set; }

    public Guid AssetId { get; private set; }
    public Asset Asset { get; private set; }

    public string? Description { get; private set; }

    public AssetFiles() { }
    public AssetFiles(string title, string filePath, Guid assetId, string? description = null)
    {
        if (assetId == null) throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

        if (string.IsNullOrWhiteSpace(title))
            throw new AssetDomainException("عنوان فایل نمی‌تواند خالی باشد. لطفاً یک عنوان معتبر وارد کنید.");

        if (string.IsNullOrWhiteSpace(filePath))
            throw new AssetDomainException("هیچ فایلی انتخاب نشده است.");

        Title = title;
        FilePath = filePath;
        AssetId = assetId;
        Description = description;
    }
    public void Update(string title, string filePath, Guid assetId, string? description = null)
    {
        if (assetId == null) throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

        if (string.IsNullOrWhiteSpace(title))
            throw new AssetDomainException("عنوان فایل نمی‌تواند خالی باشد. لطفاً یک عنوان معتبر وارد کنید.");

        if (string.IsNullOrWhiteSpace(filePath))
            throw new AssetDomainException("هیچ فایلی انتخاب نشده است.");

        Title = title;
        FilePath = filePath;
        AssetId = assetId;
        Description = description;
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);
}
