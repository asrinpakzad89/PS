namespace CMMSAPP.Domain.AggregatesModel.AssetAggregate;

public class AssetIdentity : Entity
{
    public bool IsStandard { get; private set; }

    public Guid ManufacturerId { get; private set; }
    public Manufacturer Manufacturer { get; private set; }

    public string? YearOfManufacture { get; private set; }
    public ShapeEnum? Shape { get; private set; }
    public MaterialTypeEnum? Material { get; private set; }
    public ImportanceLevelEnum? ImportanceLevel { get; private set; }

    public string? PhysicalLabel { get; private set; }
    public string? SerialNumber { get; private set; }

    public string? FunctionalDescription { get; private set; }


    public string? TechnicalSpecifications { get; private set; }

    protected AssetIdentity() { }

    public AssetIdentity(Guid assetId, bool isStandard, ImportanceLevelEnum? importanceLevel,
                         Guid manufacturerId, string? yearOfManufacture,
                         ShapeEnum? shape, MaterialTypeEnum? material, string? physicalLabel,
                         string? serialNumber, string? functionalDescription,
                         string? technicalSpecifications, string? createdBy = null)
    {
        if (assetId == null) 
            throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();

        IsStandard = isStandard;
        ManufacturerId = manufacturerId;
        YearOfManufacture = yearOfManufacture;
        Shape = shape;
        Material = material;
        ImportanceLevel = importanceLevel;
        PhysicalLabel = physicalLabel;
        SerialNumber = serialNumber;
        FunctionalDescription = functionalDescription;
        TechnicalSpecifications = technicalSpecifications;
        IsDisable = false;
        SetCreationInfo(createdBy);
    }

    public void Update(bool isStandard, ImportanceLevelEnum? importanceLevel,
                       Guid manufacturerId, string? yearOfManufacture,
                       ShapeEnum? shape, MaterialTypeEnum? material, string? physicalLabel,
                       string? serialNumber, string? functionalDescription,
                       string? technicalSpecifications, string? modifiedBy = null)
    {
        IsStandard = isStandard;
        ManufacturerId = manufacturerId;
        YearOfManufacture = yearOfManufacture;
        Shape = shape;
        Material = material;
        ImportanceLevel = importanceLevel;
        PhysicalLabel = physicalLabel;
        SerialNumber = serialNumber;
        FunctionalDescription = functionalDescription;
        TechnicalSpecifications = technicalSpecifications;

        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);
}