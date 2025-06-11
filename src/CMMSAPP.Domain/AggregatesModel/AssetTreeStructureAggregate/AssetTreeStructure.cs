namespace CMMSAPP.Domain.AggregatesModel.AssetTreeStructureAggregate;

public class AssetTreeStructure : Entity, IAggregateRoot
{
    public Guid InstalledAssetCodeId { get; private set; }
    public InstalledAssetCode InstalledAssetCode { get; private set; }

    public Guid LevelId { get; private set; }
    public Level Level { get; private set; }

    public string? Description { get; private set; }


    protected AssetTreeStructure() { }

    public AssetTreeStructure(InstalledAssetCode installedAssetCode, Level level, string? description = null, string? createdBy = null)
    {
        if (installedAssetCode == null) throw new AssetDomainException("کد تجهیز نصب‌شده نمی‌تواند خالی باشد.");
        if (level == null) throw new AssetDomainException("سطح تجهیز نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();
        InstalledAssetCodeId = installedAssetCode.Id;
        InstalledAssetCode = installedAssetCode;

        LevelId = level.Id;
        Level = level;

        Description = description;
        SetCreationInfo(createdBy);
    }

    public void Update(InstalledAssetCode installedAssetCode, Level level, string? description = null, string? modifiedBy = null)
    {
        if (installedAssetCode == null) throw new AssetDomainException("کد تجهیز نصب‌شده نمی‌تواند خالی باشد.");
        if (level == null) throw new AssetDomainException("سطح تجهیز نمی‌تواند خالی باشد.");

        InstalledAssetCodeId = installedAssetCode.Id;
        InstalledAssetCode = installedAssetCode;

        LevelId = level.Id;
        Level = level;

        Description = description;

        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);
}

